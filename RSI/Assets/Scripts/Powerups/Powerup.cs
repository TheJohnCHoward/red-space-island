using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {
	public AudioClip pickUpNoise;
	
	
	//To be overridden, currently just destroys
	public virtual void action(GameObject player){
		Network.Destroy(gameObject);
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag=="Player"){
			AudioSource.PlayClipAtPoint(pickUpNoise,transform.position);
			action(other.gameObject);
		}
	}
}
