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
		else{
			Attack2 playerAttack2 = gameObject.GetComponent("Attack2") as Attack2;
			originalAttackAmount = playerAttack2.damageAmount;
			
			playerAttack2.damageAmount*=2;
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
		else{
			Attack2 playerAttack2 = gameObject.GetComponent("Attack2") as Attack2;
			playerAttack2.damageAmount=originalAttackAmount;
		}
		base.revertPlayerToNorm ();
	}
}
