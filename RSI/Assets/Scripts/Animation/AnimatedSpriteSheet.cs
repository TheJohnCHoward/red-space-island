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
    private int prevIndex = -1;
	public bool run;
	
	//For quick Animations
	public bool looping,stopped;
	
	public float timeStart, timer;
	
	private string currSpriteSheet,prevSpriteSheet;
	
 
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
		if(!stopped && run){
			
        int index = 0;
		index=index=(int)((Time.time-timeStart) * fps) % (numberOfSpritesX * numberOfSpritesY);
			
			
			if(index!=prevIndex){
			    Vector2 offset = new Vector2(iX*sizeOfSprite.x,
			                                         1-(sizeOfSprite.y*iY));
			    iX++;
						
			            if(iX / numberOfSpritesX == 1)
			            {
			                
			                
			                if(iY / numberOfSpritesY == 1)
			                {
								if(!looping){
			                		stopped=true;
								}
								else{
									iX=0;
									iY=1;
								}
			                }
							else{
								iX=0;
								if(numberOfSpritesY!=1){    
									iY++;
								}
							}
			            }
			 
			            myRenderer.material.SetTextureOffset ("_MainTex", offset);
				
				prevIndex=index;
			}
			
	 			
	        
			
		}
		
		timer+=Time.deltaTime;
    }
	
	//Sets the animation to said animation Name in the dictionary of sheets, if it exists
	
	//regular kind, loops forever
	public void setAnimation(string animationName){
		
		if(spriteSheets.ContainsKey(animationName)){
			//print("Got to animation "+animationName +", in "+gameObject.name);
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
			looping=true;
			
			stopped=false;
		}
		else{
			//print("Was not in there");
		}
	
	}
	
	//Sets the animation to said animation Name in the dictionary of sheets, if it exists
	
	//regular kind, loops forever
	public void setAnimation(string animationName, bool _looping){
		
		if(spriteSheets.ContainsKey(animationName)){
			//print("Got to animation "+animationName +", in "+gameObject.name);
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
			
			stopped=false;
			timeStart=Time.time;
			timer=Time.time;
			iX=0;
			iY=1;
			this.looping=_looping;
			prevIndex = -1;
			timeStart=Time.time;
			timer=Time.time;
			
		}
		else{
			//print("Was not in there");
		}
	
	}
}