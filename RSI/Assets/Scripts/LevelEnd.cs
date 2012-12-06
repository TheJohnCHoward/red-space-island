using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {
	public bool lastLevel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			if (!lastLevel) {
				Application.LoadLevel(Application.loadedLevel+1);
				//networkView.RPC ("LoadLevel", RPCMode.AllBuffered, Application.loadedLevel + 1);
			} else {
				// load win screen
				Application.LoadLevel("Win");
			}
		}
	}
	void OnTriggerStay(Collider other) {
		if (other.tag == "Player") {
			if (!lastLevel) {
				Application.LoadLevel(Application.loadedLevel+1);
				//networkView.RPC ("LoadLevel", RPCMode.AllBuffered, Application.loadedLevel + 1);
			} else {
				// load win screen
				Application.LoadLevel("Win");
			}
		}
	}
	
	[RPC]
	void LoadLevel(int levelPrefix) {
		Network.SetSendingEnabled(0, false);
		Network.isMessageQueueRunning = false;
		Network.SetLevelPrefix(levelPrefix);
		Application.LoadLevel(levelPrefix);
		Network.SetSendingEnabled(0, true);
		Network.isMessageQueueRunning = true;
	}
}
