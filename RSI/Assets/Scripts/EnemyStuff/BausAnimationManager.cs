using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BausAnimationManager : AnimatedSpriteSheet {
	
	
	// Use this for initialization
	void Start () {
		base.myRenderer = renderer;
		base.spriteSheets = new Dictionary<string, SpriteSheetInformation>();
		SpriteSheetInformation ssLeft= new SpriteSheetInformation("Marx/KarlMarx2MovingRight",2,2,10);
		SpriteSheetInformation ssRight= new SpriteSheetInformation("Marx/KarlMarx2MovingLeft",2,2,10);
		
		SpriteSheetInformation rushLeft= new SpriteSheetInformation("Marx/KarlMarx2RushingRight",2,2,10);
		SpriteSheetInformation rushRight= new SpriteSheetInformation("Marx/KarlMarx2RushingLeft",2,2,10);
		
		SpriteSheetInformation still= new SpriteSheetInformation("Marx/KarlMarxWaiting",2,4,10);
		
		SpriteSheetInformation punchLeft= new SpriteSheetInformation("Marx/KarlMarxStrikeLeft",2,2,12);
		SpriteSheetInformation punchRight= new SpriteSheetInformation("Marx/KarlMarxStrikeRight",2,2,12);
		
		SpriteSheetInformation lazer= new SpriteSheetInformation("Marx/KarlMarxLazer",1,1,10);
		SpriteSheetInformation prelazer= new SpriteSheetInformation("Marx/KarlMarxLazerPrep",2,2,8);
		
		base.spriteSheets.Add("Right", ssRight);
		base.spriteSheets.Add("Left",ssLeft);
		
		base.spriteSheets.Add("StrikeRight", punchRight);
		base.spriteSheets.Add("StrikeLeft",punchLeft);
		
		
		base.spriteSheets.Add("Still", still);
		base.spriteSheets.Add("Lazer", lazer);
		
		base.spriteSheets.Add("Prelazer",prelazer);
		
		base.spriteSheets.Add("RushRight",rushRight);
		base.spriteSheets.Add("RushLeft",rushLeft);
		
		base.setAnimation("Left");
	}
	
}