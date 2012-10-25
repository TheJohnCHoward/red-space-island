using UnityEngine;
using System.Collections;

public class BausRegionOne : BasicEnemy {
	public int bossHealth =1000;	
	private bool waiting =false;
	public float timer =0.0f;
	public int state =0;
	public int stateCounter=3;
	
	
	// Use this for initialization
	void Start () {
		base.health=bossHealth;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(waiting){
			if(timer<=0.0f){
				waiting=false;
			}
			else{
				timer-=Time.deltaTime;
			}
		}
		//If not waiting, do all the stuff
		else{
			
			
		}
	}
	
	/** 
	 * Causes boss to wait for specified amount of time
	 * 
	 */
	public void wait(float time){
		timer=time;
		waiting=true;
	}
}
