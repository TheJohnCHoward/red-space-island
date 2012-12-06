using UnityEngine;
using System.Collections;

public class Attack2 : MonoBehaviour {
	public int damageAmount = 5;
	// Use this for initialization
	public AudioClip strike;
	
	
	
	void Update(){
		if (Input.GetKeyDown(KeyCode.R)) {
			//print ("test");
			audio.PlayOneShot(strike);
		}
	}
	
	void OnTriggerStay(Collider other) {
		if (Input.GetKeyDown(KeyCode.R)) {
			//print ("test");
			other.SendMessage("applyDamage", damageAmount, SendMessageOptions.DontRequireReceiver);
		}
	}
}
