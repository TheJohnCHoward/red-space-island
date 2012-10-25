using UnityEngine;
using System.Collections;

public class SpeedBoost : Power {

	public float originalSpeed;
	
	public override void makeChangeInPlayer ()
	{
		
		
		Movement playerMovement = gameObject.GetComponent("Movement") as Movement;
		
		originalSpeed = playerMovement.speed;
			
		playerMovement.speed*=2;
		
		scriptName="SpeedBoost";
		base.timer=15.0f;
		
	}
	
	public override void revertPlayerToNorm ()
	{
		Movement playerMovement = gameObject.GetComponent("Movement") as Movement;
		
		playerMovement.speed=originalSpeed;
		
		
		base.revertPlayerToNorm ();
	}
}
