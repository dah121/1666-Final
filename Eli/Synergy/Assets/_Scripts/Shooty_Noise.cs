using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooty_Noise : MonoBehaviour {

    private AudioSource AS;
    public AudioClip Shoot_Clip;

	// Use this for initialization
	void Start () {
        AS = this.GetComponent<AudioSource>();		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            //AS.PlayOneShot(Shoot_Clip);
        }
		
	}
}
