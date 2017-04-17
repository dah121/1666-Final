using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Completed_Tasks : MonoBehaviour {

    public List<string> Tasks;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        Tasks = new List<string>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
