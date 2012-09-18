using UnityEngine;
using System.Collections;

public class PrototypeLevel : MonoBehaviour {
	public Transform player;
	public Transform spawn1;
	public Transform spawn2;
	public GameObject core;
	private Transform you;

	// Use this for initialization
	void Awake () {
		if (Network.isServer) {
			core.SendMessage("setPlayer", (Transform)Network.Instantiate(player, spawn1.position, spawn1.rotation, 0));
		} else {
			core.SendMessage("setPlayer", (Transform)Network.Instantiate(player, spawn2.position, spawn2.rotation , 0));
		}
	}
	
	void setPlayer(Transform you) {
		this.you = you;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
