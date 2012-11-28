using UnityEngine;
using System.Collections;


//Projectile and melee can be the same, just change the speed of Projectile, distance of projectile, and range of Weapon to reflect a fist
public class EnemyScript : BasicEnemy {
	public float rangeOfWeapon = 5.0f;
	public Projectile projectile;
	public enum MovementState{Walking, Firing, TakingDamage, Standing};
	public MovementState movementState;
	public float speedOfProjectile;
	public float mvmtSpeed = 8f;
	private float coolDownTimer = 0.0f;
	public float coolDownTime = 1.0f;
	private float playerTimer =1.5f;
	public GameObject player;
	
	//Animation stuff
	public Vector3 prevPos;
	public BasicEnemyAnimationManager animation;
	public bool facingLeft=false;
	public float stillTimer=0.0f;
	public float checkTimer=0.0f;
	
	//redness
	float redTimer=-20;
	
	public GameObject healthPowerup, speedPowerup, powerPowerup;
	
	
	public AudioClip strike, hurt;
	
	void Start(){
		coolDownTimer=coolDownTime;
	}
	
	// Update is called once per frame
	void Update () {
		if(redTimer>0){
			redTimer-=Time.deltaTime;
		}
		else if(redTimer!=-20){
			MeshRenderer mesh = animation.GetComponent("MeshRenderer") as MeshRenderer;
			mesh.material.color= new Color(1.0f,1.0f,1.0f,1.0f);
			redTimer=-20;
		}
		
		//Animation stuff
		if(transform.position.x>prevPos.x &&movementState==MovementState.Walking){
			//heading left
			
			if(facingLeft){
				animation.run=true;
			}
			else{
				//Wasn't facing left previous
				animation.setAnimation("Left");
				animation.run=true;
			}
			stillTimer=0.5f;
			facingLeft=true;
		}
		else if(transform.position.x<prevPos.x && movementState==MovementState.Walking){
			//heading right
			
			if(!facingLeft){
				animation.run=true;
			}
			else{
				//Wasn't facing right previously
				animation.setAnimation("Right");
				animation.run=true;
			}
			
			stillTimer=0.5f;
			facingLeft=false;
		}
		else if(transform.position.z!=prevPos.z && movementState==MovementState.Walking){
			//If it's going backwards, or forewards, still run
			animation.run=true;
			stillTimer=0.5f;
		}
		else if(movementState==MovementState.Firing){
			if(player!=null){
				if(player.transform.position.x>transform.position.x){
					animation.setAnimation("StrikeLeft");
				}
				else{
					animation.setAnimation("StrikeRight");
				}
			}
			else{
				if(facingLeft){
					animation.setAnimation("StrikeLeft");
				}
				else{
					animation.setAnimation("StrikeRight");
				}
			}
			animation.run=true;
		}
		else{
			//Still, dont run
			if(stillTimer<=0){
				animation.run=false;
			}
			else{
				stillTimer-=Time.deltaTime;
			}
		}
		
		//Check first if you're in range to hit a player
		
		GameObject playerHolder = FindClosestPlayer(rangeOfVision);
		
		if(playerHolder!=null){
			player=playerHolder;
		}
		
		
		if(player!=null){
			if(isPlayerInRange(player,rangeOfWeapon,1.0f)){
				//print("ever happening?");
				movementState=MovementState.Firing;
				//Add a small cooldown time to avoid endless spam
				if(coolDownTimer<=0.0f){
					coolDownTimer=coolDownTime;
					fireWeapon(player);
				}
				else{
					movementState=MovementState.Walking;
					coolDownTimer-=Time.deltaTime;
				}
			}
			//If out of weapon range
			else{
				movementState=MovementState.Walking;
				//Move toward it if in vision range
				if(isPlayerInRange(player,rangeOfVision,rangeOfVision)){
					
					//Move z first, if not equal
					if(Mathf.Abs(transform.position.z-player.transform.position.z)>1.0f){
						
						Vector3 positionToGoTo = transform.position;
						positionToGoTo.z = player.transform.position.z;
						
						transform.position = Vector3.Lerp(transform.position,positionToGoTo,4*mvmtSpeed*Time.deltaTime);
					}
					//If equal to z, move closer
					else{
						if((Mathf.Abs(player.transform.position.x-transform.position.x))>rangeOfWeapon){
							transform.position= Vector3.Lerp(transform.position,player.transform.position,mvmtSpeed*Time.deltaTime);
						}
					}
					
				}
				//Stand still
				else{
					movementState=MovementState.Standing;
				}
			}
		}
		
		if(checkTimer>0){
			checkTimer-=Time.deltaTime;
		}
		else{
			checkTimer=1.0f;
			prevPos=transform.position;
		}
	}
	
	//Returns a player if one is in range, null otherwise
	private bool isPlayerInRange(GameObject guy, float xMaxDiff, float zMaxDiff){
		float xDiff = Mathf.Abs(transform.position.x-guy.transform.position.x);
		if(xDiff<xMaxDiff){
			return true;
		}
		
		
		return false;
	}
	
	
	//Shoot the bullet
	private void fireWeapon(GameObject player){
		//Player on right
		//Seperating them as later we might want to specify a start position based on which side it is
		//player on right
		movementState=MovementState.Firing;
		audio.PlayOneShot(strike);
		if(transform.position.x<player.transform.position.x){
		
			Vector3 spawnPos = transform.position;
			spawnPos.z=player.transform.position.z;
			spawnPos.x+=0.5f;
			
			
			Projectile proj = Instantiate(projectile,spawnPos,projectile.transform.rotation) as Projectile;
			
			BombProjectile bomb = proj.GetComponent("BombProjectile") as BombProjectile;
			
			if(bomb!=null){
				bomb.groundHeight=transform.position.y-transform.localScale.y/2;
			}
			proj.shoot(false,speedOfProjectile,rangeOfWeapon+2);
		}
		else{
			Vector3 spawnPos = transform.position;
			//spawnPos.z=player.transform.position.z;
			spawnPos.x-=0.5f;
			
			Projectile proj = Instantiate(projectile,spawnPos,projectile.transform.rotation) as Projectile;
			proj.shoot(true,speedOfProjectile,rangeOfWeapon+2);
		}
	}
	
	public void applyDamage(int amount) {
		//print ("test2");
		audio.PlayOneShot(hurt);
		health -= amount;
		MeshRenderer mesh = animation.GetComponent("MeshRenderer") as MeshRenderer;
		mesh.material.color= new Color(0.8f,0.1f,0.1f,1.0f);
		redTimer=0.1f;
		
		if (health <= 0) {
			float val = Random.Range(0.0f,1.0f);
			
			if(val>0.7 && val<0.9){
				Network.Instantiate(healthPowerup,transform.position,healthPowerup.transform.rotation,1);
			}
			else if(val>0.90 && val<0.96){
				Network.Instantiate(speedPowerup,transform.position,speedPowerup.transform.rotation,1);
			}
			else if(val>0.96){
				Network.Instantiate(powerPowerup,transform.position,powerPowerup.transform.rotation,1);
			}
			
			Network.Destroy (gameObject);
		}
	}
	
}
