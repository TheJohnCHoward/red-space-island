using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {
	//To be overridden, currently just destroys
	public virtual void action(GameObject player){
		Destroy(gameObject);
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag=="Player"){
			Player p = other.GetComponent("Player") as Player;
			if(p!=null){
				p.powerupPlay();
				action(other.gameObject);
				return;
			}
			else{
				Player2 p2 = other.GetComponent("Player2") as Player2;
				if(p2!=null){
				p2.powerupPlay();
				action(other.gameObject);
				return;
			}
			}
			
			
		}
	}
}
