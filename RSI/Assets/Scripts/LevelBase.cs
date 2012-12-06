using UnityEngine;
using System.Collections;

public class LevelBase : MonoBehaviour {
	public Transform teddy;
	public Transform taft;
	public Transform teddy2;
	public Transform spawn1;
	public Transform spawn2;
	

	// Use this for initialization
	void Start () {
		Transform you;
		if (PlayerPrefs.GetInt("Player")==0) {
			you = (Transform) Instantiate(teddy, spawn1.position, spawn1.rotation);
			you.gameObject.AddComponent("Movement");
		} 
		else if(PlayerPrefs.GetInt("Player")==1) {
			you = (Transform) Instantiate(taft, spawn2.position, spawn2.rotation);
			you.gameObject.AddComponent("Movement");
		}
		else{
			you = (Transform) Instantiate(teddy2, spawn2.position, spawn2.rotation);
			you.gameObject.AddComponent("Movement2");
			Transform you2 = (Transform) Instantiate(taft, spawn1.position, spawn1.rotation);
			you2.gameObject.AddComponent("Movement");
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
