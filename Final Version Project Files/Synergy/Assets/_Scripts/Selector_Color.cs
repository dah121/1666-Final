using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector_Color : MonoBehaviour {

    public Material GreenMat;
    public Material RedMat;
    public GameControl Control;
    private Material current;
    
    // Use this for initialization
    void Start ()
    {
	}

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 3f, ~(1<<10)))
        { 
            if (hit.collider.gameObject.layer == 9)
                current = RedMat;
            else
                current = GreenMat;
        }

        if (Control.gold < 50)      //Change to reflect price
        {
            current = RedMat;
        }

        gameObject.GetComponentInChildren<Renderer>().material = current;
    }
    
}
