using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Rounds_Tracker : MonoBehaviour {
    public int[] Round_Size;
    public float[] Round_Rate;
    public int Current_Round;
    public int Num_Rounds;
    public Wave_Spawner spawner;
    public Text Rounds_Txt;
	
    // Use this for initialization
	void Start () {
        StreamReader round_reader = new StreamReader("Rounds.txt");
        Current_Round = 0;

        Num_Rounds = Int32.Parse(round_reader.ReadLine());
        Round_Size = new int[Num_Rounds];
        Round_Rate = new float[Num_Rounds];

        string round;
        string[] split = new string[2];
        int i = 0;
        do
        {
            round = round_reader.ReadLine();
            if (round != null)
            {
                split = round.Split(',');
                Round_Size[i] = Int32.Parse(split[0]);
                Round_Rate[i] = float.Parse(split[1]);
                i++;
            }
        }	while (round != null);
	}
	
	// Update is called once per frame
	void Update () {
        Rounds_Txt.text = "Round " + Current_Round + "/" + Num_Rounds;
	}

    public void Set_Round_Stats()
    {
        spawner.Set_Wave_Stats(Round_Size[Current_Round], Round_Rate[Current_Round]);
        Current_Round++;
    }
}
