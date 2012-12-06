using UnityEngine;
using System.Collections;

public class HealthPowerup : Powerup {

	public int healthIncrease=10;
	
	public override void action (GameObject player)
	{
		Player playah = player.GetComponent("Player") as Player;
		
		if(playah!=null){
			if(playah.health+healthIncrease<playah.maxHealth){
				playah.health+=healthIncrease;
			}
			else{
				playah.health=playah.maxHealth;
			}
		}
		else{
			Player2 playah2 = player.GetComponent("Player2") as Player2;
			if(playah2.health+healthIncrease<playah2.maxHealth){
				playah2.health+=healthIncrease;
			}
			else{
				playah2.health=playah2.maxHealth;
			}
		}
		base.action (player);
		
		
	}
}
