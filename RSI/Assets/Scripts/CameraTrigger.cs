using UnityEngine;
using System.Collections;

public class CameraTrigger : MonoBehaviour {
	CameraMovement cam;
	
	// Use this for initialization
	void Start () {
		GameObject camera = GameObject.Find("Main Camera");
		cam = camera.GetComponent("CameraMovement") as CameraMovement;
	}

	
	void OnTriggerEnter(Collider other){
		if(other.tag=="Player"){
			Movement mvmt = other.GetComponent("Movement") as Movement;
			
			if(mvmt!=null){
				float zBoundDifference = other.transform.position.z-mvmt.zMax;
				mvmt.zMax=other.transform.position.z;
				mvmt.zMin+= zBoundDifference;
				print("Z bounds diff: "+zBoundDifference);
				
				cam.newZVal+=zBoundDifference;
			}
		}
	}
}
