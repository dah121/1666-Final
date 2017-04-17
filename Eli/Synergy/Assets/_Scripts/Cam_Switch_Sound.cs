using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Switch_Sound : MonoBehaviour {

    public AudioClip Sound;
    private int Team;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(Sound, 1f);
        }

	}
}
