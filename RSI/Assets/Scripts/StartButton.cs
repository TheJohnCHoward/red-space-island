using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	bool mouseOver;
	
	void Start(){
		renderer.material.color=new Color(0.5f,0.5f,0.5f,1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if(mouseOver){
			if(Input.GetMouseButton(0)){
				Application.LoadLevel("Level0-Tutorial");
			}
		}
	}
	
	void OnMouseOver(){
		mouseOver=true;
		//print("Got here");
		renderer.material.color=new Color(1.0f,1.0f,1.0f,1.0f);
	}
	
	void OnMouseExit(){
		mouseOver=false;
		renderer.material.color=new Color(0.5f,0.5f,0.5f,1.0f);
	}
}
