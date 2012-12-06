using UnityEngine;
using System.Collections;

public class AnimatedPlayerButton : MonoBehaviour
{	
	public int playerNumber;
    private float iX=0;
    private float iY=1;
    public int _uvTieX = 3;
    public int _uvTieY = 2;
    public int _fps = 10;
    private Vector2 _size;
    public Renderer _myRenderer;
    private int _lastIndex = -1;
	public bool run;
 	public AnimatedPlayerButton otherPlayer;
	
	
	
    void Start ()
    {
        _size = new Vector2 (1.0f / _uvTieX ,
                             1.0f / _uvTieY);
 
        _myRenderer = renderer;
 
        if(_myRenderer == null) enabled = false;
 
        _myRenderer.material.SetTextureScale ("_MainTex", _size);
		
		if(!run){
			renderer.material.color=new Color(0.5f,0.5f,0.5f,1.0f);
		}	
    }
 
 
 
    void Update()
    {
		if(run){
	        int index = (int)(Time.timeSinceLevelLoad * _fps) % (_uvTieX * _uvTieY);
	 
	        if(index != _lastIndex)
	        {
	            Vector2 offset = new Vector2(iX*_size.x,
	                                         1-(_size.y*iY));
	            iX++;
	            if(iX / _uvTieX == 1)
	            {
	                if(_uvTieY!=1)    iY++;
	                iX=0;
	                if(iY / _uvTieY == 1)
	                {
	                    iY=1;
	                }
	            }
	 
	            _myRenderer.material.SetTextureOffset ("_MainTex", offset);
	 
	 
	            _lastIndex = index;
	        }
			
			
			if(Input.GetMouseButton(0)){
				if (PlayerPrefs.GetInt("Player")!=2) {
					PlayerPrefs.SetInt("Player",playerNumber);
				}
			}
		}
    }
	
	
	void OnMouseOver(){
		run=true;
		otherPlayer.run=false;
		renderer.material.color=new Color(1.0f,1.0f,1.0f,1.0f);
		otherPlayer.gameObject.renderer.material.color=new Color(0.5f,0.5f,0.5f,1.0f);
	}
	
	void OnMouseExit(){
		///run=false;
		//renderer.material.color=new Color(0.5f,0.5f,0.5f,1.0f);
	}
}