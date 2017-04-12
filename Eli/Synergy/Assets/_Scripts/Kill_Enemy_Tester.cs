using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill_Enemy_Tester : MonoBehaviour {

    public int income;

	// Use this for initialization
	public void MakeGold()
    {
        GameControl.control.gold += income; //get that GOOOOLD! (from killing an enemy)
        GameControl.control.SetGoldText(); //update the goldText field for displaying in the shop
    }
}
