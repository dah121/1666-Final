﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Builder : MonoBehaviour
{

    public GameObject Tower_Prefab;
    private Tower_Director Director;
    private GameControl Control;
    private RaycastHit hit;
    private int layerMask;
    private static float timer;
    public int place_on_team;

	//Zach - For place tower sound effect
	private AudioSource AS;
	public AudioClip clip;

    // Use this for initialization
    void Start()
    {
		AS = GameObject.Find ("Shot Audio").gameObject.GetComponent<AudioSource> ();

        GameObject controller_object = GameObject.Find("Tower Controller");
        Director = controller_object.GetComponent<Tower_Director>();
        Control = controller_object.GetComponent<GameControl>();
        timer = 0;
        place_on_team = 1;

        //layerMask = (1 << 8);
        layerMask |= (1 << 9);
        layerMask |= (1 << 10);
        layerMask = ~layerMask;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && timer <= 0)
        {
            timer = .5f;
            if (Physics.Raycast(transform.position, -Vector3.up, out hit, 3f, layerMask))
            {
                //Debug.Log(hit.collider.gameObject.layer);
                if ((hit.collider.gameObject.layer != 12 && hit.collider.gameObject.layer != 8) && Control.gold >= 50)       //Change to reflect actual price later
                {
					//Play sound Effect
					AS.PlayOneShot(clip, .8f);
                    GameObject tower = Instantiate(Tower_Prefab, new Vector3(transform.position.x, 0f, transform.position.z), Quaternion.identity) as GameObject;
                    tower.GetComponent<Tower_Movement_Listener>().Twr_Team = place_on_team;
                    Director.Add_Tower(tower);
                    Control.gold -= 50;         //Change to reflect actual price later
                }
            }
        }
        else
        {
            timer -= Time.deltaTime;
        } 
    }

}