using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Prototype_Nav : MonoBehaviour {

    public Transform Destination;
    public NavMeshAgent Agent;

	// Use this for initialization
	void Start ()
    {
        Agent = this.GetComponent<NavMeshAgent>();
    }

    public void StartWave(Vector3 dest)
    {
        Agent = this.GetComponent<NavMeshAgent>();
        Agent.destination = dest;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
