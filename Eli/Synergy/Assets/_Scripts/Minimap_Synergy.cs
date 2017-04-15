using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap_Synergy : MonoBehaviour {

    public Material Original_Mat;
    public Material Synergy_Mat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.layer == 10)
        {
            gameObject.GetComponent<Renderer>().material = Synergy_Mat;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.layer == 10)
        {
            gameObject.GetComponent<Renderer>().material = Original_Mat;
        }
    }
}
