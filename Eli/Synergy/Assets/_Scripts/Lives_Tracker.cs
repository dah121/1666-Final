using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lives_Tracker : MonoBehaviour {


    public static int Lives;
    public Text LivesText;
    public Text CompassLives;

	// Use this for initialization
	void Start ()
    {
        //Change This.
        Lives = 10;
	}
	
	// Update is called once per frame
	void Update ()
    {
        LivesText.text = ("Lives: " + Lives);
        CompassLives.text = ("Lives: " + Lives);

        if(Lives <= 0)
        {
            Destroy(GameObject.Find("Tower Controller"));
            SceneManager.LoadScene(5);
        }
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
