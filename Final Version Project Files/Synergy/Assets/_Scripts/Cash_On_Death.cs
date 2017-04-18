using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cash_On_Death : MonoBehaviour
{
    public bool no_payout;
    private GameControl Controller;
    public bool extra_payout;
    public Completed_Tasks Task_List;

    // Use this for initialization
    void Start()
    {
        Controller = GameObject.Find("Tower Controller").GetComponent<GameControl>();
        no_payout = false;
        extra_payout = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        if (!no_payout)
        {
            Controller.gold += 25;
            if(extra_payout)
            {
                Controller.gold += 5;
            }

            string task_name = gameObject.GetComponentInChildren<TextMesh>().text;
            task_name = task_name.Replace('\n', ' ');
            Task_List.Tasks.Add(task_name);
        }
    }
}
