using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam_Effect : MonoBehaviour {

    public LineRenderer Line;
    public float Display_Time;
    private bool destroyed;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Display_Time -= Time.deltaTime;
        if(Display_Time <= 0 && !destroyed)
        {
            destroyed = true;
            Destroy(gameObject);
        }
	}

     public void Shoot_Beam(Vector3 start, Vector3 end)
    {
        Vector3[] Positions = new Vector3[2];
        Positions[0] = start;
        Positions[0].y += .1f;
        Positions[1] = end;
        Line.SetPositions(Positions);
    }
}
