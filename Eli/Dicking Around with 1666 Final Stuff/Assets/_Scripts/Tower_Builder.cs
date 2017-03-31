using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Builder : MonoBehaviour
{

    public GameObject Tower_Prefab;
    private Tower_Director Director;
    private RaycastHit hit;
    private int layerMask;
    private static float timer;

    // Use this for initialization
    void Start()
    {
        Director = GameObject.Find("Tower Controller").GetComponent<Tower_Director>();
        timer = 0;
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
                if (hit.collider.gameObject.layer != 8)
                {
                    GameObject tower = Instantiate(Tower_Prefab, new Vector3(transform.position.x, 1f, transform.position.z), Quaternion.identity) as GameObject;
                    Director.Add_Tower(tower);
                }
            }
        }
        else
        {
            timer -= Time.deltaTime;
        } 
    }

}