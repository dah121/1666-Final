using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower_Movement_Listener : MonoBehaviour
{

    private Transform t;
    private GameObject Controller;
    public GameObject ID_Band;
    public Material Team_1_Mat, Team_2_Mat, Team_3_Mat, Team_4_Mat;
    private Image image; //Zach - for screen overlays
    public Sprite T1, T1A, T2, T2A, T3, T3A, T4, T4A; //Zach - for screen overlays
    public int Twr_Team = 0;

    // Use this for initialization
    void Start()
    {
        image = transform.FindChild("Camera/Canvas/Overlay").GetComponent<Image>();
        Controller = GameObject.Find("Tower Controller");
        t = transform;

        if (Twr_Team == 1)
        {
            ID_Band.GetComponent<Renderer>().material = Team_1_Mat;
            image.sprite = T1;
            t.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (Twr_Team == 2)
        {
            ID_Band.GetComponent<Renderer>().material = Team_2_Mat;
            image.sprite = T2;
            t.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else if (Twr_Team == 3)
        {
            ID_Band.GetComponent<Renderer>().material = Team_3_Mat;
            image.sprite = T3;
            t.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Twr_Team == 4)
        {
            ID_Band.GetComponent<Renderer>().material = Team_4_Mat;
            image.sprite = T4;
            t.rotation = Quaternion.Euler(0f, 270f, 0f);
        }
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Twr_Team == Controller.GetComponent<Controller_Mouselook>().Team)
        {
            t.rotation = Controller.transform.rotation;

            if (Twr_Team == 1)
            {
                image.sprite = T1A;
            }
            else if (Twr_Team == 2)
            {
                image.sprite = T2A;
            }
            else if (Twr_Team == 3)
            {
                image.sprite = T3A;
            }
            else if (Twr_Team == 4)
            {
                image.sprite = T4A;
            }
        }
        else
        {
            if (Twr_Team == 1)
            {
                image.sprite = T1;
            }
            else if (Twr_Team == 2)
            {
                image.sprite = T2;
            }
            else if (Twr_Team == 3)
            {
                image.sprite = T3;
            }
            else if (Twr_Team == 4)
            {
                image.sprite = T4;
            }
        }
    }

    public void update_materials()
    {
        if (Twr_Team == 1)
        {
            ID_Band.GetComponent<Renderer>().material = Team_1_Mat;
            t.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (Twr_Team == 2)
        {
            ID_Band.GetComponent<Renderer>().material = Team_2_Mat;
            t.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else if (Twr_Team == 3)
        {
            ID_Band.GetComponent<Renderer>().material = Team_3_Mat;
            t.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Twr_Team == 4)
        {
            ID_Band.GetComponent<Renderer>().material = Team_4_Mat;
            t.rotation = Quaternion.Euler(0f, 270f, 0f);
        }
    }
}