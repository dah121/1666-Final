using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Upgrade : MonoBehaviour {

    private RaycastHit hit;

	// Use this for initialization
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, -Vector3.up, out hit, 3f, ~(3<<9)))
            {
                if (hit.collider.gameObject.layer >= 8)
                {
                    open_window();
                }
            }
        }
	}

    private void open_window()
    {

    }
}
