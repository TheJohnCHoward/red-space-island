using UnityEngine;
using System.Collections;

public class TextControl : MonoBehaviour {
	
	public GameObject core;
	public bool isQuit;
	
	void OnMouseEnter() {
		//change the color of the text
		renderer.material.color = Color.red;
	}
	
	void OnMouseExit() {
		//change the color of the text
		renderer.material.color = Color.white;
	}
	
	void OnMouseUp() {
		//show lobby interface
		if (isQuit) {
			Application.Quit();
		} else {
			core.AddComponent("NetworkHandler");
		}
	}
	
}
