using UnityEngine;
using System.Collections;

public class Movement2 : MonoBehaviour {
	// player speed
	public float speed = 4;
	private float bounds = 8;
	public float zMax = 13;
	public float zMin = 0;
	public bool fixedCamera;
	public Transform mainCamera;
	
	void Start () {
		mainCamera = GameObject.Find ("Main Camera").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
		float xTranslation=0;
		if(Input.GetKey(KeyCode.A)){
			xTranslation=-1*speed;
		}
		else if(Input.GetKey(KeyCode.D)){
			xTranslation=speed;
		}
		
		float zTranslation = 0;
		
		if(Input.GetKey(KeyCode.S)){
			zTranslation=speed*-2;
		}
		else if(Input.GetKey(KeyCode.W)){
			zTranslation=speed*2;
		}
		xTranslation *= Time.deltaTime;
		zTranslation *= Time.deltaTime;
		if (transform.position.x - mainCamera.position.x <= -bounds && xTranslation < 0) {
			xTranslation = 0;
		}
		if (transform.position.x - mainCamera.position.x >= bounds - .1 && xTranslation > 0) {
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
