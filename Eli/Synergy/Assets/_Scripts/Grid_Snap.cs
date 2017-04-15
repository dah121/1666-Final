using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_Snap : MonoBehaviour
{
    private float snap_x;
    private float snap_z;

    // Use this for initialization

    void Start ()
    {
         
    }
	
	// Update is called once per frame
	void Update ()
    {
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(r, out hit))
        {   
            snap_x = hit.transform.position.x;
            snap_z = hit.transform.position.z;
        }

        transform.position = new Vector3(snap_x, 2f, snap_z);
    }
}
