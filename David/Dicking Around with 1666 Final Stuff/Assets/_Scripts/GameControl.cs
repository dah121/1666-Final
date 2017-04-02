using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public static GameControl control;

    public int gold;
    public Text goldText;

    void Awake()
    {
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
            SetGoldText();
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        SetGoldText();
    }

    public void SetGoldText()
    {
        goldText.text = "Gold: " + gold.ToString();
    }

}
