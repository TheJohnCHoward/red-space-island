using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerAnimationManager : AnimatedSpriteSheet {
	public string walkingLeft, walking, punchingLeft, punchingRight;
	
	
	// Use this for initialization
	void Start () {
		base.myRenderer = renderer;
		base.spriteSheets = new Dictionary<string, SpriteSheetInformation>();
		SpriteSheetInformation ssLeft= new SpriteSheetInformation(walkingLeft,3,2,10);
		SpriteSheetInformation ssRight= new SpriteSheetInformation(walking,3,2,10);
		
		SpriteSheetInformation punchLeft= new SpriteSheetInformation(punchingLeft,3,1,8);
		SpriteSheetInformation punchRight= new SpriteSheetInformation(punchingRight,3,1,8);
		
		base.spriteSheets.Add("Right", ssLeft);
		base.spriteSheets.Add("Left",ssRight);
		
		base.spriteSheets.Add("PunchRight", punchLeft);
		base.spriteSheets.Add("PunchLeft",punchRight);
		
		base.setAnimation("Right");
	}
	
}
