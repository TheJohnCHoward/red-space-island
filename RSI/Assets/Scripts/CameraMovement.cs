using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public float speed = 4;
	private float bounds = 1;
	public int playerCount=0;
	public float newZVal;
	
	public Movement mvmt;
	public Movement2 mvmt2;
	// Use this for initialization
	void Start () {
		newZVal = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		float xTranslation = 0;
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		
		bool move =true;
		playerCount=0;
		foreach (GameObject player in players) {
			playerCount++;
			
			Movement mvmtI = player.GetComponent("Movement") as Movement;
			if(mvmtI!=null){
				mvmt=mvmtI;
			}
			Movement2 mvmtI2 = player.GetComponent("Movement2") as Movement2;
			if(mvmtI2!=null){
				mvmt2=mvmtI2;
			}
			if (player.transform.position.x - transform.position.x < bounds) {
				move=false;
				
			}
		}
			if(move && playerCount<2){
				if(mvmt!=null && !mvmt.fixedCamera){
					speed=mvmt.speed;
				}//Added this thing in, in order to deal with fixed camera
				else if(mvmt2!=null && !mvmt2.fixedCamera){
					
					speed=mvmt2.speed;
				}
				else{
					speed=0;
				}
				
				
				xTranslation = speed * Time.deltaTime;
			}
			else if(move && playerCount==2){
				//print("Got to moving with 2");
				if(mvmt!=null && mvmt2!=null &&( !mvmt.fixedCamera && !mvmt2.fixedCamera)){
					//print("Got through all the checks");
					float speed1=mvmt.speed;
					float speed2=mvmt2.speed;
					
					if(speed1>speed2){
						//print("Set speed1: "+speed1);
						speed=speed1;
					}
					else{
						//print("Set speed2: "+speed2);
						speed=speed2;
					}
				}
				else{
					speed=0;
				}
				
			}
		
		if(mvmt!=null && mvmt2!=null &&( mvmt.fixedCamera && mvmt2.fixedCamera)){
			speed=0;
		}
		
		if(mvmt2==null && mvmt!=null && mvmt.fixedCamera){
			speed=0;
		}
		
		if(mvmt==null && mvmt2!=null && mvmt2.fixedCamera){
			speed=0;
		}
		
		//print("Speed here: "+speed);
		foreach (GameObject player in players) {
			if (player.transform.position.x - transform.position.x <= -bounds) {
				return;
			}
		}
		
		//print("Speed here2: "+speed);
		if(newZVal!=transform.position.z){
			Vector3 newPos = transform.position;
			newPos.z= newZVal;
			
			transform.position = Vector3.Lerp(transform.position,newPos,Time.deltaTime*speed);
		}
		xTranslation=speed*Time.deltaTime;
		//print("Should be moving with speed: "+xTranslation);
		transform.position += new Vector3(xTranslation, 0, 0);
	}
	
}
