using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) {
		if (Input.GetButtonDown("Light")) {
			//print ("test");
			other.SendMessage("applyDamage", 5, SendMessageOptions.DontRequireReceiver);
		}
	}
}
