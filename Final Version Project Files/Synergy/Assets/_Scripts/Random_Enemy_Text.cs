using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Random_Enemy_Text : MonoBehaviour {
    private string[] Nouns; private string[] Verbs;
    int Noun_Count = 877; int Verb_Count = 633;


    // Use this for initialization
    void Start () {
        Nouns = new string[Noun_Count]; Verbs = new string[Verb_Count];
        StreamReader noun_reader = new StreamReader("Noun_Source.txt");
        StreamReader verb_reader = new StreamReader("Verb_Source.txt");
        string n; string v;
        int i = 0;
        do
        {
            n = noun_reader.ReadLine();
            v = verb_reader.ReadLine();

            if (n != null){
                Nouns[i] = n;
            }
            if (v != null)
            {
                Verbs[i] = v;
            }
            i++;
        } while (n != null || v != null);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Get_Random_Pair(GameObject enemy)
    {
        int noun = Random.Range(0, Noun_Count);
        int verb = Random.Range(0, Verb_Count);

        string result = Verbs[verb] + '\n' + Nouns[noun];
        enemy.GetComponent<Text_Controller>().task_Name = result;
    }


}
