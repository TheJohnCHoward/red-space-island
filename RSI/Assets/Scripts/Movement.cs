using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	// The player's speed
	public float speed = 40;
	
	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
			float xTranslation = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
			float zTranslation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
			transform.position += new Vector3(xTranslation, 0, zTranslation);
	}
}
