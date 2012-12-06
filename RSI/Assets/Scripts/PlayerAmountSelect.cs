using UnityEngine;
using System.Collections;

public class PlayerAmountSelect : MonoBehaviour {
	public bool selected, mouseOver;
	public bool multi;
	public AnimatedPlayerButton teddy, taft;
	public PlayerAmountSelect other;
	public AudioClip beep;
	
	void Start(){
		PlayerPrefs.SetInt("Player",0);
		if(multi){
			renderer.material.color=new Color(0.5f,0.5f,0.5f,1.0f);
		}
		else{
			selected=true;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if(mouseOver){
			if(Input.GetMouseButton(0)){
				selected=true;
				other.selected=false;
				other.renderer.material.color=new Color(0.5f,0.5f,0.5f,1.0f);
				if(multi){
					PlayerPrefs.SetInt("Player",2);
					teddy.run=true;
					teddy.renderer.material.color=new Color(1.0f,1.0f,1.0f,1.0f);
					
					taft.run=true;
					taft.renderer.material.color=new Color(1.0f,1.0f,1.0f,1.0f);
				}
				else{
					PlayerPrefs.SetInt("Player", 0);
					
					teddy.run=true;
					teddy.renderer.material.color=new Color(1.0f,1.0f,1.0f,1.0f);
					
					taft.run=false;
					taft.renderer.material.color=new Color(0.5f,0.5f,0.5f,1.0f);
					
				}
			}
		}
		
		if(multi){
			if(Input.GetMouseButton(0)){
				audio.PlayOneShot(beep);
			}
		}
	}
	
	void OnMouseOver(){
		mouseOver=true;
		renderer.material.color=new Color(1.0f,1.0f,1.0f,1.0f);
	}
	
	void OnMouseExit(){
		mouseOver=false;
		if(!selected){
			renderer.material.color=new Color(0.5f,0.5f,0.5f,1.0f);
		}
	}
}
