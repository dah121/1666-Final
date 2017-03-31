using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Movement_Listener : MonoBehaviour
{

    private Transform t;
    private GameObject Controller;
    public GameObject ID_Band;
    public Material Team_1_Mat, Team_2_Mat, Team_3_Mat, Team_4_Mat;
    public int Twr_Team;

    // Use this for initialization
    void Start()
    {
        Controller = GameObject.Find("Tower Controller");
        t = transform;

        Twr_Team = Random.Range(1, 5);

        if (Twr_Team == 1)
            ID_Band.GetComponent<Renderer>().material = Team_1_Mat;
        else if (Twr_Team == 2)
            ID_Band.GetComponent<Renderer>().material = Team_2_Mat;
        else if (Twr_Team == 3)
            ID_Band.GetComponent<Renderer>().material = Team_3_Mat;
        else if (Twr_Team == 4)
            ID_Band.GetComponent<Renderer>().material = Team_4_Mat;


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