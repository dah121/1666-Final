using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower_Builder : MonoBehaviour
{

    public GameObject Tower_Prefab;
    public GameObject Upgrades;
    public Text Sell_Text, Upgrade_Text, Title_Text;
    private Tower_Director Director;
    private Tower_Economy Tower_Info;
    private GameControl Control;
    private RaycastHit hit;
    private int layerMask;
    private static float timer;
    public int place_on_team;

	//Zach - For place tower sound effect
	private AudioSource AS;
    public AudioClip BuildSound;
	public AudioClip UpgradeSound;
    public AudioClip SellSound;

    [HideInInspector]
    public GameObject Selected_Tower;

    private bool upgrades_open;

    // Use this for initialization
    void Start()
    {
		AS = GameObject.Find ("Universal Audio Source").gameObject.GetComponent<AudioSource> ();

        GameObject controller_object = GameObject.Find("Tower Controller");
        Director = controller_object.GetComponent<Tower_Director>();
        Control = controller_object.GetComponent<GameControl>();
        timer = 0;
        place_on_team = 1;
        upgrades_open = false;

        layerMask |= (1 << 9);
        layerMask |= (1 << 10);
        layerMask = ~layerMask;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && timer <= 0 && !upgrades_open)
        {
            timer = .5f;
            if (Physics.Raycast(transform.position, -Vector3.up, out hit, 3f, layerMask))
            {
                //Debug.Log(hit.collider.gameObject.layer);
                if ((hit.collider.gameObject.layer != 12 && hit.collider.gameObject.layer != 8) && Control.gold >= 50)       //Change to reflect actual price later
                {
					//Play sound Effect
					AS.PlayOneShot(BuildSound, .8f);
                    GameObject tower = Instantiate(Tower_Prefab, new Vector3(transform.position.x, 0f, transform.position.z), Quaternion.identity) as GameObject;
                    tower.GetComponent<Tower_Movement_Listener>().Twr_Team = place_on_team;
                    Director.Add_Tower(tower);
                    Control.gold -= 50;         //Change to reflect actual price later
                }
                else if (hit.collider.gameObject.layer == 8)
                {
                    upgrades_open = true;
                    Selected_Tower = hit.collider.gameObject;
                    Upgrades.SetActive(true);
                    Upgrades_Setup();
                }
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
        if (upgrades_open)
        {
            Sell_Text.text = "Fire\n$" + Tower_Info.Sell_Value;
            Upgrade_Text.text = "Promote\n$" + Tower_Info.Upgrade_Cost;
            Title_Text.text = Selected_Tower.name.Substring(0, Selected_Tower.name.Length - 7);
        }
    }

    public void Upgrade_Tower()
    {
        if (Control.gold >= Selected_Tower.GetComponent<Tower_Economy>().Upgrade_Cost)
        {
            Selected_Tower.GetComponent<Tower_Economy>().Upgrade++;
            AS.PlayOneShot(UpgradeSound, .85f);
            Upgrades_Setup();
        }
    }
    public void Sell_Tower()
    {
        Control.gold += Selected_Tower.GetComponent<Tower_Economy>().Sell_Value;
        Director.Remove_Tower(Selected_Tower);
        AS.PlayOneShot(SellSound, 1f);
        Destroy(Selected_Tower);
    }

    public void Upgrades_Setup()
    {
        Tower_Info = Selected_Tower.GetComponent<Tower_Economy>();
            Sell_Text.text = "Fire\n$" + Tower_Info.Sell_Value;
        Upgrade_Text.text = "Promote\n$" + Tower_Info.Upgrade_Cost;
            Title_Text.text = Selected_Tower.name.Substring(0, Selected_Tower.name.Length - 7);
    }

    public void Close_Upgrades()
    {
        Selected_Tower = null;
        Upgrades.SetActive(false);
        upgrades_open = false;
    }

}