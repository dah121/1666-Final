using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team_Assignment : MonoBehaviour {

    public GameObject Selector;
    //public GameObject Controller;     On Controller

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            Selector.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Selector.GetComponent<Tower_Builder>().place_on_team = 1;
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(r, out hit, (1 << 8)))
                {
                    hit.collider.gameObject.GetComponentInParent<Tower_Movement_Listener>().Twr_Team = 1;
                    hit.collider.gameObject.GetComponentInParent<Tower_Movement_Listener>().update_materials();
                }
            }
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            Selector.GetComponent<Tower_Builder>().place_on_team = 2;
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(r, out hit, (1 << 8)))
                {
                    hit.collider.gameObject.GetComponentInParent<Tower_Movement_Listener>().Twr_Team = 2;
                    hit.collider.gameObject.GetComponentInParent<Tower_Movement_Listener>().update_materials();
                }
            }
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            Selector.GetComponent<Tower_Builder>().place_on_team = 3;
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(r, out hit, (1 << 8)))
                {
                    hit.collider.gameObject.GetComponentInParent<Tower_Movement_Listener>().Twr_Team = 3;
                    hit.collider.gameObject.GetComponentInParent<Tower_Movement_Listener>().update_materials();
                }
            }
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            Selector.GetComponent<Tower_Builder>().place_on_team = 4;
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(r, out hit, (1 << 8)))
                {
                    hit.collider.gameObject.GetComponentInParent<Tower_Movement_Listener>().Twr_Team = 4;
                    hit.collider.gameObject.GetComponentInParent<Tower_Movement_Listener>().update_materials();
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyUp(KeyCode.Alpha3) || Input.GetKeyUp(KeyCode.Alpha4))
        {
            Selector.SetActive(true);
        }
    }
}
