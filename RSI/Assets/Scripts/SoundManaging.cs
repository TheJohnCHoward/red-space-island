using UnityEngine;
using System.Collections;

public class SoundManaging : MonoBehaviour {
	public AudioClip mainTheme;
	
	// Update is called once per frame
	void Update () {
		if(!audio.isPlaying){
			audio.clip=mainTheme;
			audio.loop=true;
			
			audio.Play();
		}
	}
}
