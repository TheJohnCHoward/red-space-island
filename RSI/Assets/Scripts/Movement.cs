using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	// player speed
	public float speed = 4;
	private float bounds = 10;
	public float zMax = 13;
	public float zMin = 0;
	public bool fixedCamera;
	public Transform mainCamera;
	
	void Start () {
		mainCamera = GameObject.Find ("Main Camera").transform;
	}
	
	// Update is called once per frame
	void Update () {
		float xTranslation = Input.GetAxis("Horizontal") * speed;
		float zTranslation = Input.GetAxis("Vertical") * speed;
		xTranslation *= Time.deltaTime;
		zTranslation *= Time.deltaTime;
		if (transform.position.x - mainCamera.position.x <= -bounds && xTranslation < 0) {
			xTranslation = 0;
		}
		if (fixedCamera && transform.position.x - mainCamera.position.x >= bounds - .1 && xTranslation > 0) {
			xTranslation = 0;
		}
		if (transform.position.z >= zMax && zTranslation > 0) {
			zTranslation = 0;
		} else if (transform.position.z <= zMin && zTranslation < 0) {
			zTranslation = 0;
		}
		transform.position += new Vector3(xTranslation, 0, zTranslation);
	}
}
