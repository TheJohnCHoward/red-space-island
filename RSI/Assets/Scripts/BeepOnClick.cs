using UnityEngine;
using System.Collections;

public class BeepOnClick : MonoBehaviour {
	public AudioClip beep;
	//Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			audio.PlayOneShot(beep);
		}
	}
}
