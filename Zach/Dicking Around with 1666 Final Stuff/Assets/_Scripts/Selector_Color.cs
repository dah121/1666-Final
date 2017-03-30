using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector_Color : MonoBehaviour {

    public Material GreenMat;
    public Material RedMat;
    private Material current;
    
    // Use this for initialization
    void Start ()
    {
	}

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        { 
            if (hit.collider.gameObject.layer == 9)
                current = RedMat;
            else
                current = GreenMat;
        }

        gameObject.GetComponentInChildren<Renderer>().material = current;
    }
    
}
