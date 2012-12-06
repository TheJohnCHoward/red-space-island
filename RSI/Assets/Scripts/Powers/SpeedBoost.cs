using UnityEngine;
using System.Collections;

public class SpeedBoost : Power {

	public float originalSpeed;
	
	public override void makeChangeInPlayer ()
	{
		
		
		Movement playerMovement = gameObject.GetComponent("Movement") as Movement;
		
		if(playerMovement!=null){
			originalSpeed = playerMovement.speed;
				
			playerMovement.speed*=2;
			
			scriptName="SpeedBoost";
			base.timer=15.0f;
		}
		else{
			Movement2 playerMovement2 = gameObject.GetComponent("Movement2") as Movement2;
			originalSpeed = playerMovement2.speed;
				
			playerMovement2.speed*=2;
			
			scriptName="SpeedBoost";
			base.timer=15.0f;
		}
		
		
	}
	
	public override void revertPlayerToNorm ()
	{
		Movement playerMovement = gameObject.GetComponent("Movement") as Movement;
		
		if(playerMovement!=null){
			playerMovement.speed=originalSpeed;
		
		
			base.revertPlayerToNorm ();
		}
		else{
			Movement2 playerMovement2 = gameObject.GetComponent("Movement2") as Movement2;
			playerMovement2.speed=originalSpeed;
		
		
			base.revertPlayerToNorm ();
		}
	}
}
