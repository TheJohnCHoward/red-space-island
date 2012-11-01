using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BasicEnemyAnimationManager : AnimatedSpriteSheet {
	public string walkingLeft, walkingRight, strikeLeft, strikeRight;
	
	
	// Use this for initialization
	void Start () {
		base.myRenderer = renderer;
		base.spriteSheets = new Dictionary<string, SpriteSheetInformation>();
		SpriteSheetInformation ssLeft= new SpriteSheetInformation(walkingLeft,3,2,10);
		SpriteSheetInformation ssRight= new SpriteSheetInformation(walkingRight,3,2,10);
		
		SpriteSheetInformation punchLeft= new SpriteSheetInformation(strikeLeft,1,1,10);
		SpriteSheetInformation punchRight= new SpriteSheetInformation(strikeRight,1,1,10);
		
		base.spriteSheets.Add("Right", ssLeft);
		base.spriteSheets.Add("Left",ssRight);
		
		base.spriteSheets.Add("StrikeRight", punchLeft);
		base.spriteSheets.Add("StrikeLeft",punchRight);
		
		base.setAnimation("Left");
	}
	
}