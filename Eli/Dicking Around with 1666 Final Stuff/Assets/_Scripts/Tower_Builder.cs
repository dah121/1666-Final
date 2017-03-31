using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Builder : MonoBehaviour
{

    public GameObject Tower_Prefab;
    private Tower_Director Director;
    private RaycastHit hit;

    // Use this for initialization
    void Start()
    {
        Director = GameObject.Find("Tower Controller").GetComponent<Tower_Director>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, -Vector3.up, out hit))
            {
                if (hit.collider.gameObject.layer <= 7)     //8 is towers, 9 is path
                {
                    GameObject tower = Instantiate(Tower_Prefab, new Vector3(transform.position.x, 1f, transform.position.z), Quaternion.identity) as GameObject;
                    Director.Add_Tower(tower);
                }
            }
        }
    }
}