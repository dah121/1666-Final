using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Start : MonoBehaviour {

	private FadingAudioSource music;
	public AudioClip shopMusic;

	// Use this for initialization
	void Start () {
		music = gameObject.GetComponent<FadingAudioSource> ();
		music.Fade (shopMusic, 1f, true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
