using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass_Selector : MonoBehaviour {
	private Image image;
	public Sprite T1, T2, T3, T4;

	private GameObject controller;

	// Use this for initialization
	void Start () {
		image = transform.FindChild("Compass").GetComponent<Image>();
		controller = GameObject.Find("Tower Controller");
	}
	
	// Update is called once per frame
	void Update () {
		int Twr_Team = controller.GetComponent<Controller_Mouselook>().Team;

		if (Twr_Team == 1) {
			image.sprite = T1;
		} else if (Twr_Team == 2) {
			image.sprite = T2;
		} else if (Twr_Team == 3) {
			image.sprite = T3;
		} else {
			image.sprite = T4;
		}
	}
}
