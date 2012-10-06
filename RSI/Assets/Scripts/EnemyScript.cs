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
	
	
	void Start(){
		coolDownTimer=coolDownTime;
	}
	
	// Update is called once per frame
	void Update () {
		//Check first if you're in range to hit a player
		GameObject playerHolder = FindClosestPlayer(rangeOfVision);
		
		if(playerHolder!=null){
			player=playerHolder;
		}
		
		if(isPlayerInRange(player,rangeOfWeapon,1.0f)){
			print("ever happening?");
			movementState=MovementState.Firing;
			//Add a small cooldown time to avoid endless spam
			if(coolDownTimer<=0.0f){
				coolDownTimer=coolDownTime;
				fireWeapon(player);
			}
			else{
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
	
	//Returns a player if one is in range, null otherwise
	private bool isPlayerInRange(GameObject guy, float xMaxDiff, float zMaxDiff){
		
		float zDiff = Mathf.Abs(transform.position.z-guy.transform.position.z);
		
		if(zDiff<zMaxDiff){
			float xDiff = Mathf.Abs(transform.position.x-guy.transform.position.x);
			if(xDiff<xMaxDiff){
				return true;
			}
		}
		
		return false;
	}
	
	
	//Should the bullet
	private void fireWeapon(GameObject player){
		//Player on right
		//Seperating them as later we might want to specify a start position based on which side it is
		//player on right
		if(transform.position.x<player.transform.position.x){
		
			Vector3 spawnPos = transform.position;
			spawnPos.z=player.transform.position.z;
			spawnPos.x+=0.5f;
			
			
			Projectile proj = Instantiate(projectile,spawnPos,transform.rotation) as Projectile;
			proj.shoot(false,speedOfProjectile,rangeOfWeapon);
		}
		else{
			Vector3 spawnPos = transform.position;
			spawnPos.z=player.transform.position.z;
			spawnPos.x-=0.5f;
			
			Projectile proj = Instantiate(projectile,spawnPos,transform.rotation) as Projectile;
			proj.shoot(true,speedOfProjectile,rangeOfWeapon);
		}
	}
	
	public void applyDamage(int amount) {
		print ("test2");
		health -= amount;
		if (health <= 0) {
			Network.Destroy (gameObject);
		}
	}
	
}
