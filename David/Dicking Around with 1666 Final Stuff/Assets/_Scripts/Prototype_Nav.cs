using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Prototype_Nav : MonoBehaviour {

    public Transform Destination;

	// Use this for initialization
	void Start () {
        this.GetComponent<NavMeshAgent>().destination = Destination.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
