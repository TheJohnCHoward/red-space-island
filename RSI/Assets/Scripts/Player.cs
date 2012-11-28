using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float health = 100;
	public float maxHealth = 100;
	public GUIStyle style;
	public GUIStyle style2;
	public PlayerAnimationManager animation;
	private bool facingRight, punching;
	public float punchTimer=0.0f;
	public float redTimer=0.0f;
	
	public AudioClip hurt, powerup;
	
	// Use this for initialization
	void Start () {
		redTimer=-20;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Network.Destroy (this.gameObject);
			if (GameObject.FindGameObjectsWithTag("Player").Length - 1 == 0) {
				networkView.RPC ("LoadLevel", RPCMode.AllBuffered, 2);
			} else {
				//print ("test");
			}
		}
		
		
		if(redTimer>0){
			redTimer-=Time.deltaTime;
		}
		else if(redTimer!=-20){
			MeshRenderer mesh = animation.GetComponent("MeshRenderer") as MeshRenderer;
			mesh.material.color= new Color(1.0f,1.0f,1.0f,1.0f);
			redTimer=-20;
		}
		
		if(Input.GetAxis("Horizontal")==-1 || Input.GetKeyDown(KeyCode.LeftArrow)){
			if(animation.looping ||(!animation.looping && animation.stopped)){
				animation.setAnimation("Left");
				animation.run=true;
			}
			((BoxCollider) collider).center = new Vector3(-1, 0, 0);
			facingRight=false;
		}
		else if(Input.GetAxis("Horizontal") == 1 || Input.GetKeyDown(KeyCode.RightArrow)){
			if(animation.looping ||(!animation.looping && animation.stopped)){
				animation.setAnimation("Right");
				animation.run=true;
			}
			facingRight=true;
			((BoxCollider) collider).center = new Vector3(1, 0, 0);
		}
		else if(Input.GetButtonDown("Vertical")|| Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)){
			animation.run=true;
		}
		else{
			//if(punchTimer<0.0f){
			if(animation.looping){
				if(facingRight){
					animation.setAnimation("Right");
				}
				else{
					animation.setAnimation("Left");
				}
			
			
				animation.run=false;
			}
			else{
				animation.run=true;
			}
		}
		
		if(Input.GetButtonDown("Light") || Input.GetKeyDown(KeyCode.J)){
			
			if(facingRight){
				animation.setAnimation("PunchRight", false);
			}
			else{
				animation.setAnimation("PunchLeft", false);
			}
			animation.run=true;
			punchTimer=0.1f;
		}
		
	}
	
	void OnCollisionEnter(Collision other){
		
		if(other.transform.tag=="Projectile"){
			Projectile proj = other.transform.gameObject.GetComponent("Projectile") as Projectile;
			audio.PlayOneShot(hurt);
			health-= proj.damageAmount;
			MeshRenderer mesh = animation.GetComponent("MeshRenderer") as MeshRenderer;
			mesh.material.color= new Color(0.8f,0.1f,0.1f,1.0f);
			redTimer=0.1f;
		}
		
		
	}
	
	void OnTriggerEnter(Collider other){
		
		if(other.transform.tag=="Projectile"){
			Projectile proj = other.transform.gameObject.GetComponent("Projectile") as Projectile;
			audio.PlayOneShot(hurt);
			health-= proj.damageAmount;
			MeshRenderer mesh = animation.GetComponent("MeshRenderer") as MeshRenderer;
			mesh.material.color= new Color(0.8f,0.1f,0.1f,1.0f);
			redTimer=0.1f;
		}
		
	}
	//POWERUP GOT
	public void powerupPlay(){
		audio.PlayOneShot(powerup);
	}
	
	[RPC]
	void LoadLevel(int levelPrefix) {
		Network.SetSendingEnabled(0, false);
		Network.isMessageQueueRunning = false;
		Network.SetLevelPrefix(levelPrefix);
		Application.LoadLevel(levelPrefix);
		Network.SetSendingEnabled(0, true);
		Network.isMessageQueueRunning = true;
	}
}
