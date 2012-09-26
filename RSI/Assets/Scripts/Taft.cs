using UnityEngine;
using System.Collections;

public class Taft : MonoBehaviour {
	public float health = 100;
	public float maxHealth = 100;
	public GUIStyle style;
	public GUIStyle style2;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Network.Destroy (this.gameObject);
		}
	}
	
	void OnGUI() {
		GUI.Box(new Rect(Screen.width - 310, 10, 300, 30), "");
		GUI.Label(new Rect(Screen.width - 305, 15, 290, 20), "", style);
		GUI.Label(new Rect(Screen.width - 305 + health / maxHealth * 290, 15, (maxHealth - health) / maxHealth * 290, 20), "", style2);
		GUI.Box(new Rect(Screen.width - 310, 10, 300, 30), "Taft");
	}
	
	void OnCollisionEnter(Collision other){
		print("This happening");
		if(other.transform.tag=="Projectile"){
			Projectile proj = other.transform.gameObject.GetComponent("Projectile") as Projectile;
			
			health-= proj.damageAmount;
			if(health<=0){
				Destroy(gameObject);
			}
		}
	}
}
