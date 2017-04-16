﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives_Tracker : MonoBehaviour {


    public static int Lives;
    public Text LivesText;

	// Use this for initialization
	void Start ()
    {
        //Change This.
        Lives = 5;
	}
	
	// Update is called once per frame
	void Update ()
    {
        LivesText.text = ("Lives: " + Lives);
    }

    public void Set_Lives(int lives)
    {
        Lives = lives;
    }

    public void Decrement_Lives()
    {
        Lives--;
    }
}
