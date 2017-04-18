using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Prototype_Nav : MonoBehaviour {

    public Transform Destination;
    public NavMeshAgent Agent;
    public Lives_Tracker lives;

	// Use this for initialization
	void Start ()
    {
        Agent = this.GetComponent<NavMeshAgent>();
    }

    public void StartWave(Vector3 dest)
    {
        if (Agent == null)
            Agent = this.GetComponent<NavMeshAgent>();
        Agent.destination = dest;
    }
	
	// Update is called once per frame
	void Update () {
        if (this.Agent.remainingDistance != 0 && this.Agent.remainingDistance < .1f)
        {
            gameObject.GetComponent<Cash_On_Death>().no_payout = true;
            Destroy(gameObject);
            lives.Decrement_Lives();
        }
    }
}
