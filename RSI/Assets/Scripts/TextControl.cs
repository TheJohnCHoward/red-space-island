using UnityEngine;
using System.Collections;

public class TextControl : MonoBehaviour {
	
	public GameObject core;
	public GUITexture background;
	public GUIText quit, credits;
	public bool isQuit;
	
	void OnMouseEnter() {
		//change the color of the text
		guiText.fontStyle = FontStyle.Bold;
	}
	
	void OnMouseExit() {
		//change the color of the text
		guiText.fontStyle = FontStyle.Normal;
	}
	
	void OnMouseUp() {
		//show lobby interface
		if (isQuit) {
			Application.Quit();
		} else {
			((NetworkHandler) core.GetComponent("NetworkHandler")).showNetworkInterface = true;
			background.texture = null;
			guiText.text = "";
			guiText.collider.enabled = false;
			quit.renderer.enabled = false;
			//quit.collider.enabled = false;
		}
	}
	
}
