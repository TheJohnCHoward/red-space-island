using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public float speed = 4;
	public float bounds = 6;
	public float newZVal;
	// Use this for initialization
	void Start () {
		newZVal = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		float xTranslation = 0;
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		foreach (GameObject player in players) {
			if (player.transform.position.x - transform.position.x > bounds) {
				Movement mvmt = player.GetComponent("Movement") as Movement;
				
				if(mvmt!=null){
					speed=mvmt.speed;
				}
				
				
				xTranslation = speed * Time.deltaTime;
			}
		}
		foreach (GameObject player in players) {
			if (player.transform.position.x - transform.position.x <= -bounds) {
				return;
			}
		}
		
		if(newZVal!=transform.position.z){
			Vector3 newPos = transform.position;
			newPos.z= newZVal;
			
			transform.position = Vector3.Lerp(transform.position,newPos,Time.deltaTime*speed);
		}
		
		transform.position += new Vector3(xTranslation, 0, 0);
	}
	
}
