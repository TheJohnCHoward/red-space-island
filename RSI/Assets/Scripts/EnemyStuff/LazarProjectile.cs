using UnityEngine;
using System.Collections;

public class LazarProjectile : Projectile {
	public float timeLasting=1.0f;
	public int damage=1;
	public float timer=0.0f;
	public bool doDamage;
	
	public override void OnCollisionEnter (Collision other)
	{
		if(other.gameObject.tag=="Player"){
			Player p = other.gameObject.GetComponent("Player") as Player;
			p.health-=damage;
		}
	}
	
	public override void shoot (bool shootingLeft, float speed, float distance)
	{
		
		timer=speed;	
	}
	
	public void OnTriggerStay(Collider other){
		if(other.tag=="Player"){
			Player p = other.gameObject.GetComponent("Player") as Player;
			if(doDamage){
				p.health-=damage;
			}
			
			doDamage=!doDamage;
		}
	}
	
	public void OnCollisionStay(Collision other){
		if(other.gameObject.tag=="Player"){
			Player p = other.gameObject.GetComponent("Player") as Player;
			
			if(doDamage){
				p.health-=damage;	
			}
			doDamage=!doDamage;
		}
	}
	

	// Update is called once per frame
	void Update () {
		if(timer>0.0f){
			timer-=Time.deltaTime;
			
			renderer.material.color= Color.Lerp(renderer.material.color,Color.red,Time.deltaTime*4);
		}
		else{
			Network.Destroy(gameObject);
		}
	}
}
