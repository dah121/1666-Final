using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Director : MonoBehaviour {

    private List<GameObject> Towers_Master;
    public Camera Minimap_Cam, Rounds_Cam, Lives_Cam;
    public Shooty_Noise Shot_Noise;
    public GameObject Spawn_Logic;
    private GameObject Spawner;

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
        reset_posititons(tower);
    }

    public void Remove_Tower(GameObject tower)
    {
        Towers_Master.Remove(tower);
    }

    public void Activate_Towers()
    {
        for(int i = 0; i< Towers_Master.Count; i++)
        {
            Towers_Master[i].GetComponentInChildren<Camera>().enabled = true;
            Towers_Master[i].GetComponentInChildren<Tower_Movement_Listener>().enabled = true;
            Towers_Master[i].GetComponentInChildren<Tower_Attack>().enabled = true;
        }

        Shot_Noise.enabled = true;
        Minimap_Cam.gameObject.SetActive(true);
        Rounds_Cam.gameObject.SetActive(true);
        Lives_Cam.gameObject.SetActive(true);

        Spawner = Instantiate(Spawn_Logic, transform) as GameObject;
        Spawner.SetActive(true);
    }

    public void Deactivate_Towers()
    {
        for (int i = 0; i < Towers_Master.Count; i++)
        {
            Towers_Master[i].GetComponentInChildren<Camera>().enabled = false;
            Towers_Master[i].GetComponentInChildren<Tower_Movement_Listener>().enabled = false;
            Towers_Master[i].GetComponentInChildren<Tower_Attack>().enabled = false;
            reset_posititons(Towers_Master[i]);
        }

        Shot_Noise.enabled = false;
        Minimap_Cam.gameObject.SetActive(false);
        Rounds_Cam.gameObject.SetActive(false);
        Lives_Cam.gameObject.SetActive(false);
        Destroy(Spawner);
    }

    private void reset_posititons(GameObject tower)
    {
        int team = tower.GetComponent<Tower_Movement_Listener>().Twr_Team;
        Transform t = tower.transform;

        if (team == 0)
            t.rotation = Quaternion.Euler(0f, 0f, 0f);
        else if (team == 1)
            t.rotation = Quaternion.Euler(0f, 90f, 0f);
        else if (team == 2)
            t.rotation = Quaternion.Euler(0f, 180f, 0f);
        else if (team == 3)
            t.rotation = Quaternion.Euler(0f, 270f, 0f);
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

        Lives_Cam.rect = new Rect(0f, .33f, .33f, .34f);
        Minimap_Cam.rect = new Rect(0.33f, 0.33f, 0.34f, 0.34f);
        Rounds_Cam.rect = new Rect(.67f, .33f, .33f, .34f);

    }
}
