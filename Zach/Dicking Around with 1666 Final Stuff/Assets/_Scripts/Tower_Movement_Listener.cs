using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Movement_Listener : MonoBehaviour
{

    private Transform t;
    private GameObject Controller;
    public int Twr_Team;

    // Use this for initialization
    void Start()
    {
        Controller = GameObject.Find("Tower Controller");
        t = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Twr_Team == Controller.GetComponent<Controller_Mouselook>().Team)
        {
            t.rotation = Controller.transform.rotation;
        }
    }
}