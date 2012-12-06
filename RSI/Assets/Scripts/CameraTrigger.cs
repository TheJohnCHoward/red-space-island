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
			
			GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
			
			foreach (GameObject player in players){
				Movement mvmt = player.GetComponent("Movement") as Movement;
				
				
				
				if(mvmt!=null){
					float zBoundDifference = other.transform.position.z-mvmt.zMax;
					mvmt.zMax=other.transform.position.z;
					mvmt.zMin+= zBoundDifference;
					//print("Z bounds diff: "+zBoundDifference);
					
					cam.newZVal+=zBoundDifference;
				}
				
				Movement2 mvmt2 = player.GetComponent("Movement2") as Movement2;
				
				
				
				if(mvmt2!=null){
					float zBoundDifference = other.transform.position.z-mvmt2.zMax;
					mvmt2.zMax=other.transform.position.z;
					mvmt2.zMin+= zBoundDifference;
					//print("Z bounds diff: "+zBoundDifference);
					
					//cam.newZVal+=zBoundDifference;
				}
			}
			
			//Destroy(gameObject);
		}
	}
}
