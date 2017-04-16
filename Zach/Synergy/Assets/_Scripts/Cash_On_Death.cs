using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cash_On_Death : MonoBehaviour
{
    public bool reached_end;
    private GameControl Controller;

    // Use this for initialization
    void Start()
    {
        Controller = GameObject.Find("Tower Controller").GetComponent<GameControl>();
        reached_end = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        if (!reached_end)
        {
            Controller.gold += 25;
            string task_name = gameObject.GetComponentInChildren<TextMesh>().text;
            task_name = task_name.Replace('\n', ' ');
            Completed_Tasks.Tasks.Add(task_name);
        }
    }
}
