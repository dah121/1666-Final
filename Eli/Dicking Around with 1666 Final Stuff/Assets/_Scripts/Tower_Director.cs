using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Director : MonoBehaviour {

    private List<GameObject> Towers_Master;
    public Camera Minimap_Cam;

	// Use this for initialization
	void Start () {
        Towers_Master = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void Add_Tower(GameObject tower)
    {
        Towers_Master.Add(tower);
    }

    public void Remove_Tower(GameObject tower)
    {
        Towers_Master.Remove(tower);
    }

    public void Activate_Cameras()
    {
        for(int i = 0; i< Towers_Master.Count; i++)
        {
            Towers_Master[i].GetComponentInChildren<Camera>().enabled = true;
        }
    }

    public void Deactivate_Cameras()
    {
        for (int i = 0; i < Towers_Master.Count; i++)
        {
            Towers_Master[i].GetComponentInChildren<Camera>().enabled = false;
        }
    }

    public void Divide_Screen()
    {
        int num_towers = Towers_Master.Count;
        int num_bottom;
        int num_top = num_towers/2;
        if(num_towers % 2 == 0)
            num_bottom = num_top;
        else
            num_bottom = num_top + 1;

        float top_width = 1f / num_top;
        float bottom_width = 1f / num_bottom;
        float height = 0.33f;
        int i;
        for(i = 0; i < num_top; i++)
        {
            Towers_Master[i].GetComponentInChildren<Camera>().rect = new Rect(i * top_width, .67f, top_width, height);
        }
        for(i = num_top; i < num_towers; i++)
        {
            Towers_Master[i].GetComponentInChildren<Camera>().rect = new Rect((i - num_top) * bottom_width, 0f, bottom_width, height);
        }

        Minimap_Cam.rect = new Rect(0.33f, 0.33f, 0.34f, 0.34f);

    }
}
