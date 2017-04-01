using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Zach

public class Tower_Attack : MonoBehaviour {
    public string weapon_type; //hitscan, aoe?, status?
    public float damage;
    public float dot_rate; //rate as how many seconds between damage pulses
    public float dot_length; //length as # of damage pulses
    public float dot_damage;
    public float slow;
    public float fire_rate;
    public bool auto_fire;
    public GameObject towerController;
    public Camera cam;

    private GameObject enemy;
    private Enemy_Damager damager;

	// Use this for initialization
	void Start () {
        enemy = null;
        damager = null;
        towerController = GameObject.Find("Tower Controller"); //Remove if public variable used
        cam = transform.FindChild("Camera").gameObject.GetComponent<Camera>(); //Remove if public variable used
	}
	
	// Update is called once per frame
	void Update () {
		if(!auto_fire && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(weapon_type == "hitscan" && Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                if(hit.collider.gameObject.layer == 11) //11 = enemy layer
                {
                    enemy = hit.collider.gameObject.transform.root.gameObject;
                    damager = enemy.GetComponent<Enemy_Damager>();

                    damager.SendSource(this.gameObject);                  
                }
            }
        }
	}
}
