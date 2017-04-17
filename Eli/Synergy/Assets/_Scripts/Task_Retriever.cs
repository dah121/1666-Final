using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task_Retriever : MonoBehaviour {

    public Text Task_Text;
    public Completed_Tasks Tasks_Completed;

	// Use this for initialization
	void Start ()
    {
        Cursor.lockState = CursorLockMode.None;
        Tasks_Completed = GameObject.Find("CompletedTasks").GetComponent<Completed_Tasks>();
        string task_string = "";
        for(int i = 0; i<Tasks_Completed.Tasks.Count; i++)
        {
            task_string += Tasks_Completed.Tasks[i] + "\n";
        }
        Task_Text.text = task_string;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
