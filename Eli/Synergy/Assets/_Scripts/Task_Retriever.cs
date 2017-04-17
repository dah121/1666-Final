using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task_Retriever : MonoBehaviour {

    public Text Task_Text;

	// Use this for initialization
	void Start ()
    {
        string task_string = "";
        for(int i = 0; i<Completed_Tasks.Tasks.Count; i++)
        {
            task_string += Completed_Tasks.Tasks[i] + "\n";
        }
        Task_Text.text = task_string;
        Destroy(GameObject.Find("Tower Controller"));
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
