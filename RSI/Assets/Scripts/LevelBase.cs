using UnityEngine;
using System.Collections;

public class LevelBase : MonoBehaviour {
	public Transform teddy;
	public Transform taft;
	public Transform spawn1;
	public Transform spawn2;

	// Use this for initialization
	void Start () {
		Transform you;
		if (Network.isServer) {
			you = (Transform) Network.Instantiate(teddy, spawn1.position, spawn1.rotation, 0);
		} else {
			you = (Transform) Network.Instantiate(taft, spawn2.position, spawn2.rotation , 0);
		}
		you.gameObject.AddComponent("Movement");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
