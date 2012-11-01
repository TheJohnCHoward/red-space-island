using UnityEngine;
using System.Collections;

public class HealthPowerup : Powerup {

	public int healthIncrease=10;
	
	public override void action (GameObject player)
	{
		Player playah = player.GetComponent("Player") as Player;
		
		if(playah.health+healthIncrease<playah.maxHealth){
			playah.health+=healthIncrease;
		}
		else{
			playah.health=playah.maxHealth;
		}
		base.action (player);
		
		
	}
}
