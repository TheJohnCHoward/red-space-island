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
				networkView.RPC ("LoadLevel", RPCMode.AllBuffered, Application.loadedLevel + 1);
			} else {
				// load win screen
				networkView.RPC ("LoadLevel", RPCMode.AllBuffered, 1);
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
