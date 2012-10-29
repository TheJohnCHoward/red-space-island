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
				Application.LoadLevel(Application.loadedLevel + 1);
			} else {
				// load win screen
				print ("win");
			}
		}
	}
}
