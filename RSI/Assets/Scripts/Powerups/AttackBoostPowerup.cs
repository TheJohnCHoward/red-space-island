using UnityEngine;
using System.Collections;

public class AttackBoostPowerup :Powerup {
	public override void action (GameObject player)
	{
		player.AddComponent("AttackBoost");
		base.action(player);
	}
	
	
}
