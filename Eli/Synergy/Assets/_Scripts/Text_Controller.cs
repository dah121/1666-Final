using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Controller : MonoBehaviour {

    public string task_Name;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.GetComponentInChildren<TextMesh>().text = task_Name;
	}
}
