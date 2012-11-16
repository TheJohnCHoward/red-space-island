using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BausAnimationManager : AnimatedSpriteSheet {
	
	
	// Use this for initialization
	void Start () {
		base.myRenderer = renderer;
		base.spriteSheets = new Dictionary<string, SpriteSheetInformation>();
		SpriteSheetInformation ssLeft= new SpriteSheetInformation("Marx/RoboxMarxMovingLeft",2,1,10);
		SpriteSheetInformation ssRight= new SpriteSheetInformation("Marx/RoboKarlMarxMovingRight",2,1,10);
		
		
		
		SpriteSheetInformation punchLeft= new SpriteSheetInformation("Marx/RoboKarlMarxStrikeLeft",1,1,10);
		SpriteSheetInformation punchRight= new SpriteSheetInformation("Marx/RoboKarlMarxStrikeRight",1,1,10);
		
		SpriteSheetInformation lazer= new SpriteSheetInformation("Marx/RoboKarlMarxLazar",1,1,10);
		
		base.spriteSheets.Add("Right", ssRight);
		base.spriteSheets.Add("Left",ssLeft);
		
		base.spriteSheets.Add("StrikeRight", punchRight);
		base.spriteSheets.Add("StrikeLeft",punchLeft);
		
		base.spriteSheets.Add("Lazer", lazer);
		
		base.setAnimation("Left");
	}
	
}