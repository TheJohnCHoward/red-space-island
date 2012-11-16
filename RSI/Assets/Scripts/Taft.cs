using UnityEngine;
using System.Collections;

public class Taft : Player {
	void OnGUI() {
		GUI.Box(new Rect(10, 60, 300, 30), "");
		GUI.Label(new Rect(15, 65, 290, 20), "", style);
		GUI.Label(new Rect(15 + health / maxHealth * 290, 65, (100 - health) / maxHealth * 290, 20), "", style2);
		GUI.Box(new Rect(10, 60, 300, 30), "Taft");
	}
}
