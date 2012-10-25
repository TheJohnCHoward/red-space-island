using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {
	
	//To be overridden, currently just destroys
	public virtual void action(GameObject player){
		Destroy(gameObject);
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag=="Player"){
			action(other.gameObject);
		}
	}
}
