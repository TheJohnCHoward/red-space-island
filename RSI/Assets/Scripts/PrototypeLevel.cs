using UnityEngine;
using System.Collections;

// Spawns the players on the network and adds the necessary components
public class PrototypeLevel : MonoBehaviour {
	public Transform player;
	public Transform spawn1;
	public Transform spawn2;
	public GameObject core;

	// Use this for initialization
	void Awake () {
		Transform you;
		// spawn player
		if (Network.isServer) {
			you = (Transform)Network.Instantiate(player, spawn1.position, spawn1.rotation, 0);
		} else {
			you = (Transform)Network.Instantiate(player, spawn2.position, spawn2.rotation , 0);
		}
		// Add necessary components to the player's game object
		you.gameObject.AddComponent("Movement");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
