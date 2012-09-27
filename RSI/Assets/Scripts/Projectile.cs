using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public bool shooting;
	public int damageAmount;
	private float speed = 5.0f;
	private Vector3 destination;
	
	// Update is called once per frame
	void Update () {
		if(shooting){
			Vector3 difference = destination-transform.position;
			
			
			//sqrMagnitude is cheaper to call than magnitude
			if(difference.sqrMagnitude>1){
				transform.position = Vector3.Lerp(transform.position,destination,Time.deltaTime*speed);
				
			}
			else{
				Destroy(gameObject);
			}
		}
	}
	
	//To be called when the projectile is instantiated
	public void shoot(bool shootingLeft, float speed, float distance){
		shooting=true;
		this.speed=speed;
		
		
		if(shootingLeft){
			destination= transform.position - new Vector3(distance,0.0f,0.0f);
		}
		else{
			destination= transform.position + new Vector3(distance,0.0f,0.0f);
		}
		
		
	}
	
	void OnCollisionEnter(Collision other){
		
		if(other.transform.tag=="Player"){
			Destroy(gameObject);
		}
	}
	
	
	
	
}
