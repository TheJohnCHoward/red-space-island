using UnityEngine;
using System.Collections;

public class Teddy : MonoBehaviour {
	public float health = 100;
	public float maxHealth = 100;
	public GUIStyle style;
	public GUIStyle style2;
	public PlayerAnimationManager animation;
	private bool facingRight, punching;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Network.Destroy (this.gameObject);
		}
		
		if(!punching){
			if(Input.GetKey(KeyCode.LeftArrow)){
				animation.setAnimation("Left");
				animation.run=true;
				facingRight=false;
			}
			else if(Input.GetKey(KeyCode.RightArrow)){
				animation.setAnimation("Right");
				animation.run=true;
				facingRight=true;
			}
			else if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)){
				animation.run=true;
			}
			else{
				animation.run=false;
			}
		}
		if(Input.GetButtonDown("Light")){
			punching=true;
			if(facingRight){
				animation.setAnimation("PunchRight",false);
			}
			else{
				animation.setAnimation("PunchLeft",false);
			}
		}
		
		if (punching) {
			//print ("test");
			print("Punch");
			if(facingRight){
				//animation.setAnimation("PunchRight",false);
			}
			else{
				//animation.setAnimation("PunchLeft", false);
			}
			
			if(!animation.quickRun){
				if(facingRight){
					animation.setAnimation("Right");
				}
				else{
					animation.setAnimation("Left");
				}
				
				punching=false;
			}
		}
		
	}
	
	void OnGUI() {
		GUI.Box(new Rect(10, 10, 300, 30), "");
		GUI.Label(new Rect(15, 15, 290, 20), "", style);
		GUI.Label(new Rect(15 + health / maxHealth * 290, 15, (100 - health) / maxHealth * 290, 20), "", style2);
		GUI.Box(new Rect(10, 10, 300, 30), "Teddy");
	}
	
	void OnCollisionEnter(Collision other){
		
		if(other.transform.tag=="Projectile"){
			Projectile proj = other.transform.gameObject.GetComponent("Projectile") as Projectile;
			
			health-= proj.damageAmount;
			if(health<=0){
				Destroy(gameObject);
			}
		}
	}
	
	void OnTriggerEnter(Collider other){
		
		if(other.transform.tag=="Projectile"){
			Projectile proj = other.transform.gameObject.GetComponent("Projectile") as Projectile;
			
			health-= proj.damageAmount;
			if(health<=0){
				Destroy(gameObject);
			}
		}
	}
}
