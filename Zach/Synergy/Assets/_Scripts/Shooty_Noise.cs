using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooty_Noise : MonoBehaviour {

    private AudioSource AS;
    public AudioClip Shoot_Clip;
    public bool auto;

	// Use this for initialization
	void Start () {
        auto = false;
        AS = this.GetComponent<AudioSource>();		
	}
	
	// Update is called once per frame
	void Update () {

        if (!auto && Input.GetMouseButtonDown(0))
        {
            AS.PlayOneShot(Shoot_Clip, 1f);
        }
		else if(auto)
        {
            AS.PlayOneShot(Shoot_Clip, 1f);
            auto = false;
        }
	}
}
