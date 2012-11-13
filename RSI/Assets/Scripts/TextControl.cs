using UnityEngine;
using System.Collections;

public class TextControl : MonoBehaviour {
	
	public GameObject core;
	public GameObject background, quit;
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
			((NetworkHandler) core.GetComponent("NetworkHandler")).showNetworkInterface = true;
			background.renderer.enabled = false;
			renderer.enabled = false;
			collider.enabled = false;
			quit.renderer.enabled = false;
			quit.collider.enabled = false;
		}
	}
	
}
