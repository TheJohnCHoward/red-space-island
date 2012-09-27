using UnityEngine;
using System.Collections;


//Projectile and melee can be the same, just change the speed of Projectile, distance of projectile, and range of Weapon to reflect a fist
public class EnemyScript : BasicEnemy {
	public float rangeOfWeapon = 5.0f;
	public Projectile projectile;
	public enum MovementState{Walking, Firing, TakingDamage, Standing};
	public MovementState movementState;
	public float speedOfProjectile, distanceOfProjectile;
	public float mvmtSpeed = 8f;
	private float coolDownTimer = 0.0f;
	public float coolDownTime = 1.0f;
	public GameObject player;
	
	
	// Update is called once per frame
	void Update () {
		//Check first if you're in range to hit a player
		player = getPlayerInRange(rangeOfWeapon);
		
		if(player!=null){
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
		//If that fails, try finding a player
		else{
			movementState=MovementState.Walking;
			player = FindClosestPlayer();
			
			
			//Move toward it
			if(player!=null){
				
				//Move z first, if not equal
				if(Mathf.Abs(transform.position.z-player.transform.position.z)<0.1){
					
					Vector3 positionToGoTo = transform.position;
					positionToGoTo.z = player.transform.position.z;
					
					transform.position = Vector3.Lerp(transform.position,positionToGoTo,mvmtSpeed*Time.deltaTime);
				}
				//If equal to z, move closer
				else{
					transform.position= Vector3.Lerp(transform.position,player.transform.position,mvmtSpeed*Time.deltaTime);
				}
				//player=null;
			}
			//Stand still
			else{
				movementState=MovementState.Standing;
			}
		}
	}
	
	//Returns a player if one is in range, null otherwise
	private GameObject getPlayerInRange(float x){
		RaycastHit hit;
		
		if(Physics.Raycast(transform.position, Vector3.left, out hit)){
			if(hit.collider.gameObject.tag=="Player"){
				if(((hit.collider.gameObject.transform.position.x-transform.position.x)<rangeOfWeapon)){
					return hit.collider.gameObject;
				}
			}
		}
		if(Physics.Raycast(transform.position, Vector3.right, out hit)){
			if(hit.collider.gameObject.tag=="Player"){
				if(((transform.position.x-hit.collider.gameObject.transform.position.x)<rangeOfWeapon)){
						return hit.collider.gameObject;
				}
			}
		}
		
		return null;
	}
	
	
	//Should the bullet
	private void fireWeapon(GameObject player){
		
		//Player on right
		//Seperating them as later we might want to specify a start position based on which side it is
		if(transform.position.x<player.transform.position.x){
			Projectile proj = Instantiate(projectile,transform.position,transform.rotation) as Projectile;
			proj.shoot(false,speedOfProjectile,distanceOfProjectile);
		}
		else{
			Projectile proj = Instantiate(projectile,transform.position,transform.rotation) as Projectile;
			proj.shoot(true,speedOfProjectile,distanceOfProjectile);
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
