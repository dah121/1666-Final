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
        control = gameObject.GetComponent<GameControl>();
        SetGoldText();
    }

    void Update()
    {
        SetGoldText();
    }

    public void SetGoldText()
    {
        goldText.text = "Stock Options: $" + gold.ToString();
    }

}
