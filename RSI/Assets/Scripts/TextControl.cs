using UnityEngine;
using System.Collections;

public class TextControl : MonoBehaviour {
	
	public GameObject core;
	public GameObject storyText;
	public GUITexture background;
	public GUIText start, story, credits, back;
	public bool isStory;
	public bool isCredits;
	public bool isBack;
	public Camera mainCamera;
	private float time;
	private bool storyWait;
	public Texture creditsTexture;
	public GameObject creditsScreen;
	private Object storyObject;
	
	void OnMouseEnter() {
		//change the color of the text
		//guiText.fontStyle = FontStyle.Bold;
	}
	
	void OnMouseExit() {
		//change the color of the text
		//guiText.fontStyle = FontStyle.Normal;
	}
	
	void OnMouseUp() {
		//show lobby interface
		if (isStory) {
			background.enabled = false;
			start.enabled = false;
			story.enabled = false;
			credits.enabled = false;
			mainCamera.backgroundColor = Color.black;
			storyObject = Instantiate (storyText);
			time = Time.time;
			storyWait = true;
		} else if (isCredits) {
			background.enabled = false;
			creditsScreen.guiTexture.enabled = true;
			credits.enabled = false;
			start.enabled = false;
			story.enabled = false;
			back.enabled = true;
		} else if (isBack) {
			creditsScreen.guiTexture.enabled = false;
			background.enabled = true;
			back.enabled = false;
			credits.enabled = true;
			start.enabled = true;
			story.enabled = true;
		} else {
			((NetworkHandler) core.GetComponent("NetworkHandler")).showNetworkInterface = true;
			background.enabled = false;
			start.enabled = false;
			story.enabled = false;
			credits.enabled = false;
			//guiText.text = "";
			//guiText.collider.enabled = false;
			//quit.renderer.enabled = false;
			//quit.collider.enabled = false;
		}
	}
	
	void OnGUI() {
		if (storyWait) {
			if (Time.time - time > 35 || Input.GetKeyDown (KeyCode.Escape)) {
				background.enabled = true;
				start.enabled = true;
				story.enabled = true;
				credits.enabled = true;
				storyWait = false;
				mainCamera.backgroundColor = Color.red;
				Destroy (storyObject);
			}
		}
	}
	
}
