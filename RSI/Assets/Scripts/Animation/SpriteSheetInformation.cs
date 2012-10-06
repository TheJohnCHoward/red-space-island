using UnityEngine;
using System.Collections;

public class SpriteSheetInformation{
	public string fileName;
	public int numberOfSpritesX,numberOfSpritesY, fps;
	public Vector2 sizeOfSprite;
	
	
	public SpriteSheetInformation(string _fileName, int _numberOfSpritesX, int _numberOfSpritesY, int _fps){
		this.fileName=_fileName;
		numberOfSpritesX=_numberOfSpritesX;
		numberOfSpritesY=_numberOfSpritesY;
		
		fps=_fps;
		sizeOfSprite=new Vector2 (1.0f / numberOfSpritesX ,
                             1.0f / numberOfSpritesY);
		
	}
}
