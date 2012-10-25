using UnityEngine;
using System.Collections;

public class SpeedBoostPowerup : Powerup {
	
	public override void action (GameObject player)
	{
		//No reason for the difference of how to add
		player.AddComponent<SpeedBoost>();
		
		base.action(player);
	}
}
