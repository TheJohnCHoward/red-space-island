using UnityEngine;
using System.Collections;

public class PlayerHealthTest : MonoBehaviour {
	public int health = 10;
	
	void OnCollisionEnter(Collision other){
		print("This happening");
		if(other.transform.tag=="Projectile"){
			Projectile proj = other.transform.gameObject.GetComponent("Projectile") as Projectile;
			
			health-= proj.damageAmount;
			if(health<0){
				Destroy(gameObject);
			}
		}
	}
}
