using UnityEngine;
using System.Collections;

public class AttackBoost : Power {
	public int originalAttackAmount;
	
	
	public override void makeChangeInPlayer ()
	{
		
		
		Attack playerAttack = gameObject.GetComponent("Attack") as Attack;
		if(playerAttack!=null){
			originalAttackAmount = playerAttack.damageAmount;
			
			playerAttack.damageAmount*=2;
		}
		scriptName="AttackBoost";
		timer=5.0f;
		
	}
	
	public override void revertPlayerToNorm ()
	{
		
		Attack playerAttack = gameObject.GetComponent("Attack") as Attack;
		if(playerAttack!=null){
			playerAttack.damageAmount=originalAttackAmount;
		}
		base.revertPlayerToNorm ();
	}
}
