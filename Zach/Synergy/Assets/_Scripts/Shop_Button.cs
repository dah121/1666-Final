using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Button : MonoBehaviour {

    public int cost;

    void Update()
    {
        if (GameControl.control.gold < cost)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
    }
    
    public void BtnOnClick()
    {
        GameControl.control.gold -= cost;
    }

    public void UpgradeTower(int level)
    {
            //upgrade the tower(s)
    }
}
