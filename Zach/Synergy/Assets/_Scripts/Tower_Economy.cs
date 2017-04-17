using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Economy : MonoBehaviour {

    public int Upgrade;
    public int Cost;
    public int Sell_Value;
    public int Upgrade_Cost;

	// Use this for initialization
	void Start () {
        Upgrade = 1;
        Sell_Value = (Cost / 2) * Upgrade;
        Upgrade_Cost = Cost * (Upgrade + 1);
    }
	
	// Update is called once per frame
	void Update () {
        Sell_Value = (Cost / 2) * Upgrade;
        Upgrade_Cost = Cost * (Upgrade + 1);
    }
}
