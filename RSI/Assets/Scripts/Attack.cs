using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
	public int damageAmount = 5;
	// Use this for initialization
	public AudioClip strike;
	
	
	
	void Update(){
		if (Input.GetButtonDown("Light")) {
			//print ("test");
			audio.PlayOneShot(strike);
		}
	}
	
	void OnTriggerStay(Collider other) {
		if (Input.GetButtonDown("Light")) {
			//print ("test");
			other.SendMessage("applyDamage", damageAmount, SendMessageOptions.DontRequireReceiver);
		}
	}
}
