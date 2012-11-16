using UnityEngine;
using System.Collections;

public class StarWarsText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.y+=Time.deltaTime*3;
		pos.z+= Time.deltaTime*3;
		
		transform.position=pos;
	}
}
