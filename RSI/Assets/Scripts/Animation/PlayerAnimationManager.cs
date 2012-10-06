using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerAnimationManager : AnimatedSpriteSheet {
	
	
	
	// Use this for initialization
	void Start () {
		base.myRenderer = renderer;
		base.spriteSheets = new Dictionary<string, SpriteSheetInformation>();
		SpriteSheetInformation ssLeft= new SpriteSheetInformation("WalkingLeft",3,2,10);
		SpriteSheetInformation ssRight= new SpriteSheetInformation("Walking",3,2,10);
		
		base.spriteSheets.Add("Right", ssLeft);
		base.spriteSheets.Add("Left",ssRight);
		
		
		
		
		base.setAnimation("Right");
	}
	
}
