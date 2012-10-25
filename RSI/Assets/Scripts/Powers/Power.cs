using UnityEngine;
using System.Collections;

public class Power : MonoBehaviour {

	public bool begin =false;
	public bool notSet=true;
	//How long the power lasts
	public float timer =0.0f;
	public string scriptName ="Power";
	
	// Update is called once per frame
	void Update () {
		if(!begin){
			begin=true;
		}
		else{
			if(notSet){
				makeChangeInPlayer();
				notSet=false;
			}
			else{
				if(timer>0){
					timer-=Time.deltaTime;
				}
				else{
					revertPlayerToNorm();
				}
			}
		}
	}
	
	//Makes the necessary change in the player
	public virtual void makeChangeInPlayer(){
		
	}
	
	//Reverts player back to normal and destorys this script
	public virtual void revertPlayerToNorm(){
		Destroy(GetComponent(scriptName));
	}
}
