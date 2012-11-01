using UnityEngine;
using System.Collections;

public class CameraTrigger : MonoBehaviour {
	GameObject cam;
	public int moveCameraAmount;
	
	// Use this for initialization
	void Start () {
		cam = GameObject.Find("Main Camera");
		
	}

	
	void OnTriggerEnter(Collider other){
		if(other.tag=="Player"){
			Vector3 camPos = cam.transform.position;
			
			camPos.z+=moveCameraAmount;
			cam.transform.position=camPos;
			Network.Destroy(gameObject);
		}
	}
}
