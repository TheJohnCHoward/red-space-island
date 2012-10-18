using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AnimatedSpriteSheet : MonoBehaviour
{	
    private float iX=0;
    private float iY=0;
    public int numberOfSpritesX = 1;
    public int numberOfSpritesY = 1;
    public int fps = 10;
	public Dictionary<string, SpriteSheetInformation> spriteSheets;
    private Vector2 sizeOfSprite;
    public Renderer myRenderer;
    private int lastIndex = -1;
	public bool run;
	
	//For quick Animations
	public bool quickRun;
	public float timeStart;
	
	private string currSpriteSheet,prevSpriteSheet;
	
	//For testing
	private bool Normal;
 
    void Start ()
	{
		run=true;
		
        sizeOfSprite = new Vector2 (1.0f / numberOfSpritesX ,
                             1.0f / numberOfSpritesY);
 
        myRenderer = renderer;
 
        if(myRenderer == null) enabled = false;
 
        myRenderer.material.SetTextureScale ("_MainTex", sizeOfSprite);
		
		
		spriteSheets = new Dictionary<string, SpriteSheetInformation>();
		
    }
 
 
 
    void Update()
    {
		if(run){
			sizeOfSprite = new Vector2 (1.0f / numberOfSpritesX ,
                             1.0f / numberOfSpritesY);
			
			//Figures out what index it should be at
	        int index = (int)(Time.timeSinceLevelLoad * fps) % (numberOfSpritesX * numberOfSpritesY);
	 
			
			//Loops forever
	        if(index != lastIndex)
	        {
				
				
	            Vector2 offset = new Vector2(iX*sizeOfSprite.x,
	                                         1-(sizeOfSprite.y*iY));
	            iX++;
	            if(iX / numberOfSpritesX == 1)
	            {
	                if(numberOfSpritesY!=1){    
						iY++;
	                	iX=0;
					}
					
	                if(iY / numberOfSpritesY == 1)
	                {
	                    iY=0;
	                }
	            }
	 
	            myRenderer.material.SetTextureOffset ("_MainTex", offset);
	 
	 
	            lastIndex = index;
	        }
		}
		
		if(quickRun){
			
			sizeOfSprite = new Vector2 (1.0f / numberOfSpritesX ,
                             1.0f / numberOfSpritesY);
			
			//Figures out what index it should be at
	        int index = (int)((Time.timeSinceLevelLoad-timeStart) * fps) % (numberOfSpritesX * numberOfSpritesY);
	 
			//print("Index: "+index +". Lastindex: "+lastIndex);
			//Loops forever
	        if(index != lastIndex-1)
	        {
				print("If: "+index);
				//print("Index: "+index);
	            Vector2 offset = new Vector2(iX*sizeOfSprite.x,
	                                         1-(sizeOfSprite.y*iY));
	            iX++;
	            if(iX / numberOfSpritesX == 1)
	            {
	                if(numberOfSpritesY!=1){    
						iY++;
	                	iX=0;
					}
	                if(iY / numberOfSpritesY == 1)
	                {
	                    iY=0;
	                }
	            }
	 
	            myRenderer.material.SetTextureOffset ("_MainTex", offset);
	 
	 
	            //lastIndex = index;
	        }
			else{
				//print("Else: "+index);
				quickRun=false;
				print("Prev animation: "+prevSpriteSheet);
				setAnimation(prevSpriteSheet);
				//myRenderer.material.SetTextureOffset ("_MainTex", new Vector2(0,1));
			}
		}
    }
	
	//Sets the animation to said animation Name in the dictionary of sheets, if it exists
	
	//regular kind, loops forever
	public void setAnimation(string animationName){
		if(spriteSheets.ContainsKey(animationName)){
			if(currSpriteSheet!=animationName){
				prevSpriteSheet=currSpriteSheet;
			}
			SpriteSheetInformation info = spriteSheets[animationName];
			currSpriteSheet=animationName;
			renderer.material.mainTexture= (Texture2D)Resources.Load( info.fileName, typeof(Texture2D));
			numberOfSpritesX=info.numberOfSpritesX;
			numberOfSpritesY=info.numberOfSpritesY;
			
			fps=info.fps;
			sizeOfSprite=info.sizeOfSprite;
			myRenderer.material.SetTextureScale ("_MainTex", sizeOfSprite);
			
			//lastIndex = numberOfSpritesX*numberOfSpritesY;
		}
	}
	
	public void setAnimation(string animationName, bool loop){
		if(loop){
			if(spriteSheets.ContainsKey(animationName)){
				if(currSpriteSheet!=animationName){
					prevSpriteSheet=currSpriteSheet;
				}
				SpriteSheetInformation info = spriteSheets[animationName];
				currSpriteSheet=animationName;
				renderer.material.mainTexture= (Texture2D)Resources.Load( info.fileName, typeof(Texture2D));
				numberOfSpritesX=info.numberOfSpritesX;
				numberOfSpritesY=info.numberOfSpritesY;
				
				fps=info.fps;
				sizeOfSprite=info.sizeOfSprite;
				myRenderer.material.SetTextureScale ("_MainTex", sizeOfSprite);
				
				
				
				//lastIndex = numberOfSpritesX*numberOfSpritesY;
			}
		}
		else{
			if(spriteSheets.ContainsKey(animationName)){
				if(currSpriteSheet!=animationName){
					prevSpriteSheet=currSpriteSheet;
				}
				
				SpriteSheetInformation info = spriteSheets[animationName];
				currSpriteSheet=animationName;
				renderer.material.mainTexture= (Texture2D)Resources.Load( info.fileName, typeof(Texture2D));
				numberOfSpritesX=info.numberOfSpritesX;
				numberOfSpritesY=info.numberOfSpritesY;
				
				fps=info.fps;
				sizeOfSprite=info.sizeOfSprite;
				myRenderer.material.SetTextureScale ("_MainTex", sizeOfSprite);
				
				//Special stuff
				lastIndex = (numberOfSpritesX*numberOfSpritesY);
				timeStart=Time.timeSinceLevelLoad;
				
				
				quickRun=true;
				run=false;
			}
		}
	}
	
}