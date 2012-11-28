using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {
	//To be overridden, currently just destroys
	public virtual void action(GameObject player){
		Network.Destroy(gameObject);
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag=="Player"){
			Player p = other.GetComponent("Player") as Player;
			
			p.powerupPlay();
			
			action(other.gameObject);
		}
	}
}
