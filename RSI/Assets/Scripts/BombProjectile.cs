using UnityEngine;
using System.Collections;

public class BombProjectile : Projectile {
	
	private float gravitySpeed;
	public float explosionRadius= 3.0f;
	private float currExplosionRadius=0.0f;
	public float groundHeight=11.0f;
	private float bombTimer = 1.5f;
	
	public override void Update ()
	{
		
		
		if(transform.position.y>groundHeight){
			base.Update();
			Vector3 fallAmount = transform.position;
			
			fallAmount.y-=gravitySpeed;
			
			transform.position=fallAmount;
			
			if(gravitySpeed<6.0f){
				gravitySpeed+=0.5f;
			}
		}
		else{
			Explode();
		}
	}
	
	public override void Explode(){
		if(bombTimer>0){
			bombTimer-=Time.deltaTime;
			rigidbody.isKinematic=false;
		}
		else{
			rigidbody.isKinematic=true;
			if(currExplosionRadius<explosionRadius){
				currExplosionRadius+=0.5f;
				Vector3 currRadius = collider.transform.localScale;
				
				currRadius*=1.2f;
				collider.transform.localScale=currRadius;
				transform.localScale=currRadius;
			}
			else{
				Destroy(gameObject);
			}
		}
	}
	
	public override void shoot (bool shootingLeft, float speed, float distance)
	{
		base.shoot (shootingLeft, speed, 2*distance);
		
		gravitySpeed=0.0f;
		currExplosionRadius=0.0f;
		
	}
	
	public override void OnCollisionEnter (Collision other)
	{
		base.OnCollisionEnter (other);
	}
	
	public void OnTriggerEnter(Collider other){
		if(other.tag=="Player"){
			Destroy(gameObject);
		}
	}
	
}
