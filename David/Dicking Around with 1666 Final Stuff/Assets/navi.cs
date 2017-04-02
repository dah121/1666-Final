using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navi : MonoBehaviour {

    public GameObject dest;

    // Use this for initialization
    void Start () {
        this.GetComponent<NavMeshAgent>().destination = dest.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
    }
}
