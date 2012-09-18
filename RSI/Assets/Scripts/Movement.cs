using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public Transform you;
	public float speed = 40;
	
	void setPlayer(Transform you) {
		this.you = you;
	}
	
	// Update is called once per frame
	void Update () {
		if (you != null) {
			float zTranslation = Input.GetAxis("Vertical") * speed;
			float xTranslation = Input.GetAxis("Horizontal") * speed;
			zTranslation *= Time.deltaTime;
			xTranslation *= Time.deltaTime;
			you.position += new Vector3(xTranslation, 0, zTranslation);
		}
	}
}
