using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synergy_Explosion : MonoBehaviour {

    public ParticleSystem ps;
    
    // Use this for initialization
    void Start () {
        ps = this.GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
		if (!ps.IsAlive())
        {
            Destroy(gameObject);
        }
	}
}
