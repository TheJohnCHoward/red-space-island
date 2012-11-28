using UnityEngine;
using System.Collections;

public class BausRegionOne : BasicEnemy {	
	public float timer =0.0f;
	public int state =0;
	public int stateCounter=3;
	public const int MELEE = 1;
	public const int BULLRUSH =2;
	public const int LAZAR = 3;
	
	public Vector3 goalLocation;
	private bool rushing;
	
	//Things to be changed per level
	public int availableAttacks=1;
	public float speed=0.3f;
	public float rangeOfSight=30.0f;
	public float waitTime=1.0f;
	
	public Projectile punchProjectile;
	public float rangeOfPunch = 2.0f;
	public float speedOfPunch = 7.0f;
	
	public int jumpDamage=10;
	
	public Projectile lazar;
	public float rangeOfLazar = 10.0f;
	//How long lazar lasts
	public float speedOfLazar=3.0f;
	public BausAnimationManager animation;
	Vector3 prevPos;
	bool facingLeft=false;
	public AudioClip hurt, strike;
	public float redTimer=-20;
	
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
		
		
		if(stateCounter>0){
			switch(state){
			case 0:
				Waiting();
				break;
			case MELEE:
				Melee();
				break;
			case BULLRUSH:
				Rushing();
				break;
			case LAZAR:
				Lazaring();
				break;
				
			}
		}
		else{
			//Generate new state
			stateCounter=3;
			float midState = Random.Range(0.0f,(float)(availableAttacks+1));
			
			//print("MidState: "+midState);
			if(midState>0.3 && midState<1.0f){
				state=MELEE;
				
			}
			else if(midState>1.0f && midState<2.0f){
				
				//GONNA HAVE TO BE BULLRUSH
				state=BULLRUSH;
			}
			else if(midState>2.0f && midState<3.0f){
				state=LAZAR;
			}
			else{
				state=0;
				//print("EVER GETTING WAIT?");
				
			}
			
			if(state==0){
				//print("Got to wait once again");
				if(animation.currSpriteSheet!="Still"){
					animation.setAnimation("Still");
				}
				timer=waitTime;
			}
			//print("State was: "+state);
		}
		
		//If not moving, don't make rumble
		if(prevPos==transform.position){
			audio.loop=false;
		}
		else{
			audio.loop=true;
		}
		
		
		prevPos=transform.position;
	}
	
	/** 
	 * Causes boss to wait for specified amount of time
	 * 
	 */
	public void wait(float time){
		timer=time;
		state=0;
	}
	
	void Waiting(){
		if(timer<=0.0f){
			stateCounter=0;
			//animation.setAnimation("Still");
		}
		else{
			timer-=Time.deltaTime;
		}
	}
	
	void Melee(){
		if(goalLocation==Vector3.zero){
			goalLocation=FindClosestPlayer(rangeOfSight).transform.position;
			//Gotta be a bit higher than the player
			goalLocation.y=12.4f;
		}
		else{
			goalLocation=FindClosestPlayer(rangeOfSight).transform.position;
			goalLocation.y=12.4f;
			Vector3 differenceToGoal = goalLocation-transform.position;
			if(differenceToGoal.magnitude<3){
				//Punch time
				Punch();
				
				
			}
			else{
				//TRYING A DIFFERENT MOVEMENT SCHEME
				Vector3 movementVector = goalLocation-transform.position;
				
				movementVector.Normalize();
				
				movementVector*=speed*Time.deltaTime*4;
				//transform.position=Vector3.Lerp(transform.position,goalLocation,Time.deltaTime*speed);
				Vector3 newPos =transform.position;
				newPos+=movementVector;
				
				if(transform.position.x>newPos.x){
					//Going right
					//print("Getting right as true");
					facingLeft=false;
					animation.setAnimation("Right");
					animation.run=true;
				}
				else if(transform.position.x<newPos.x){
					//print("Getting left as true");
					facingLeft=true;
					animation.setAnimation("Left");
					animation.run=true;
				}
				
				transform.position=newPos;
				
				
			}
		}
		
	}
	
	void Lazaring(){
		if(goalLocation==Vector3.zero){
			goalLocation=FindClosestPlayer(rangeOfSight).transform.position;
			
			//Gotta be a bit higher than the player
			goalLocation.y=12.4f;
		}
		else{
			Vector3 differenceToGoal = goalLocation-transform.position;
			if(differenceToGoal.magnitude<4){
				//Punch time
				LazarShoot();
				
				goalLocation=Vector3.zero;
				stateCounter--;
			}
			else{
				Vector3 movementVector = goalLocation-transform.position;
				
				movementVector.Normalize();
				
				movementVector*=speed*Time.deltaTime*4;
				//transform.position=Vector3.Lerp(transform.position,goalLocation,Time.deltaTime*speed);
				Vector3 newPos =transform.position;
				newPos+=movementVector;
				
				if(transform.position.x>newPos.x){
					//Going right
					//print("Getting right as true");
					facingLeft=false;
					animation.setAnimation("Right");
					animation.run=true;
				}
				else if(transform.position.x<newPos.x){
					//print("Getting left as true");
					facingLeft=true;
					animation.setAnimation("Left");
					animation.run=true;
				}
				transform.position=newPos;
				//transform.position=Vector3.Lerp(transform.position,goalLocation,Time.deltaTime*speed);
			}
		}
	}
	
	
	void Rushing(){
		audio.PlayOneShot(strike);
		rushing=true;
		if(goalLocation==Vector3.zero){
			GameObject player = FindClosestPlayer(rangeOfSight);
			if(player!=null){
				goalLocation= player.transform.position;
				//Gotta be a bit higher than the player
				goalLocation.y=12.4f;
			}
		}
		else{
			//print("RUSHING");
			Vector3 differenceToGoal = goalLocation-transform.position;
			if(differenceToGoal.magnitude<3){
				//Gone far enough
				goalLocation=Vector3.zero;
				stateCounter--;
				rushing=false;
				
			}
			else{
				Vector3 movementVector = goalLocation-transform.position;
				
				movementVector.Normalize();
				
				movementVector*=speed*Time.deltaTime*8;
				//transform.position=Vector3.Lerp(transform.position,goalLocation,Time.deltaTime*speed);
				Vector3 newPos =transform.position;
				newPos+=movementVector;
				
				if(transform.position.x>newPos.x){
					//Going right
					//print("Getting right as true");
					facingLeft=false;
					animation.setAnimation("RushRight");
					animation.run=true;
				}
				else if(transform.position.x<newPos.x){
					//print("Getting left as true");
					facingLeft=true;
					animation.setAnimation("RushLeft");
					animation.run=true;
				}
				transform.position=newPos;
				//transform.position=Vector3.Lerp(transform.position,goalLocation,Time.deltaTime*speed*2);
			}
		}
		
	}
	
	void Punch(){
		//Goal is on the right
		if(transform.position.x<goalLocation.x){
			if(animation.currSpriteSheet!="StrikeRight"){
				animation.setAnimation("StrikeRight", false);
			}
			if(animation.stopped){
				Vector3 spawnPos = transform.position;
				spawnPos.z=transform.position.z;
				spawnPos.x+=0.5f;
						
				Projectile proj = Network.Instantiate(punchProjectile,spawnPos,transform.rotation,1) as Projectile;
				proj.shoot(false,speedOfPunch,rangeOfPunch);
				audio.PlayOneShot(strike);
				goalLocation=Vector3.zero;
				stateCounter--;
				animation.setAnimation(animation.prevSpriteSheet);
			}
		}
		else{
			if(animation.currSpriteSheet!="StrikeLeft"){
				animation.setAnimation("StrikeLeft",false);
			}
			if(animation.stopped){
				Vector3 spawnPos = transform.position;
				spawnPos.z=transform.position.z;
				spawnPos.x-=0.5f;
						
				Projectile proj = Network.Instantiate(punchProjectile,spawnPos,transform.rotation,1) as Projectile;
				proj.shoot(true,speedOfPunch,rangeOfPunch);
				audio.PlayOneShot(strike);
				goalLocation=Vector3.zero;
				stateCounter--;
				animation.setAnimation(animation.prevSpriteSheet);
			}
		}
	}
	
	
	
	
	//Lazar will go in both directions
	void LazarShoot(){
		if(animation.currSpriteSheet!="Prelazer"){
			animation.setAnimation("Prelazer", false);
		}
		//Instantiate both parts
		//One on left
		
		if(animation.stopped){
			animation.setAnimation("Lazer");
			Vector3 leftPos = transform.position;
			leftPos.x=transform.position.x-lazar.transform.localScale.x/2-lazar.gameObject.transform.localScale.x/2;
			Projectile proj = Network.Instantiate(lazar,leftPos,lazar.transform.rotation,1) as Projectile;
			proj.shoot(true,speedOfLazar,rangeOfLazar);
			
			//One on right
			Vector3 rightPos = transform.position;
			rightPos.x=transform.position.x+lazar.transform.localScale.x/2+lazar.gameObject.transform.localScale.x/2;
			
			Projectile proj2 = Network.Instantiate(lazar,rightPos,lazar.transform.rotation,1) as Projectile;
			proj2.shoot(true,speedOfLazar,rangeOfLazar);
			audio.PlayOneShot(strike);
			wait(speedOfLazar);
		}
		
		
	}
	
	void OnTriggerEnter(Collider other){
		if(rushing){
			if(other.tag=="Player"){
				print("Hit playert");
				Player playah = other.gameObject.GetComponent("Player") as Player;
				audio.PlayOneShot(strike);
				playah.health-=jumpDamage;
			}
		}
	}
	void OnCollisionEnter(Collision other){
		if(rushing){
			if(other.gameObject.tag=="Player"){
				print("Hit playerxc");
				Player playah = other.gameObject.GetComponent("Player") as Player;
				audio.PlayOneShot(strike);
				playah.health-=jumpDamage;
			}
		}
	}
	
	
	
	public void applyDamage(int amount) {
		//print ("test2");
		health -= amount;
		
		audio.PlayOneShot(hurt);
		MeshRenderer mesh = animation.GetComponent("MeshRenderer") as MeshRenderer;
		mesh.material.color= new Color(0.8f,0.1f,0.1f,1.0f);
		redTimer=0.1f;
		if (health <= 0) {
			//Unpause players
			
			GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
			
			foreach(GameObject player in players){
				if(player!=null){
					Movement mvmt = player.GetComponent("Movement") as Movement;
					
					if(mvmt!=null){
						mvmt.fixedCamera=false;
					}
				}
			}
			
			Network.Destroy (gameObject);
		}
	}
}
