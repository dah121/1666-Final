using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Zach

public class Tower_Attack : MonoBehaviour {
    public string weapon_type; //hitscan, aoe?, status?

    public int Upgrade_Level;

    public float base_damage; //added by Eli. Total Damage = base*upgrade level
    public float base_slow; 
    public float base_dot; 

    public float damage;
    public float slow;
    public float dot_damage;
    public float dot_rate; //rate as how many seconds between damage pulses
    public float dot_length; //length as # of damage pulses

    public float fire_rate;
    public bool isAccountant;
    public bool auto_fire;
    private float auto_timer;

    public GameObject towerController;
    public Camera cam;

    public Transform Beam_Origin;
    public Beam_Effect Beam_Eff;

    private GameObject enemy;
    private Enemy_Damager damager;

    public AudioClip shootSound;

	// Use this for initialization
	void Start () {
        auto_timer = fire_rate;
        Upgrade_Level = gameObject.GetComponent<Tower_Economy>().Upgrade;

        damage = base_damage * Upgrade_Level;
        slow = base_slow * Upgrade_Level;
        dot_damage = base_dot * Upgrade_Level;
        
        enemy = null;
        damager = null;
        towerController = GameObject.Find("Tower Controller"); //Remove if public variable used
        cam = transform.FindChild("Camera").gameObject.GetComponent<Camera>(); //Remove if public variable used
        this.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(auto_timer >= 0)
        {
            auto_timer -= Time.deltaTime;
        }

        Upgrade_Level = gameObject.GetComponent<Tower_Economy>().Upgrade;
        damage = base_damage * Upgrade_Level;
        slow = base_slow * Upgrade_Level;
        dot_damage = base_dot * Upgrade_Level;

        if (!auto_fire && Input.GetMouseButtonDown(0))
        {
            GameObject.Find("Universal Audio Source").GetComponent<AudioSource>().PlayOneShot(shootSound, 1f);

            Vector3 Beam_Dest;

            RaycastHit hit;
            if (weapon_type == "hitscan" && Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
            {
                //Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.layer == 11) //11 = enemy layer
                {
                    enemy = hit.collider.gameObject.transform.root.gameObject;
                    damager = enemy.GetComponent<Enemy_Damager>();

                    Beam_Dest = hit.collider.transform.position;
                    damager.SendSource(this.gameObject);
                }
                else
                {
                    Beam_Dest = transform.forward;
                }
                Beam_Effect beam = Instantiate(Beam_Eff, transform);
                beam.Shoot_Beam(Beam_Origin.position, Beam_Dest);
            }
        }
        else if(auto_fire && Input.GetMouseButton(0))
        {
            if(auto_timer < 0)
            {
                auto_timer = fire_rate;
                GameObject.Find("Universal Audio Source").GetComponent<Shooty_Noise>().auto = true;

                Vector3 Beam_Dest;

                RaycastHit hit;
                if (weapon_type == "hitscan" && Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
                {
                    //Debug.Log(hit.collider.gameObject.name);
                    if (hit.collider.gameObject.layer == 11) //11 = enemy layer
                    {
                        enemy = hit.collider.gameObject.transform.root.gameObject;
                        damager = enemy.GetComponent<Enemy_Damager>();

                        Beam_Dest = hit.collider.transform.position;
                        damager.SendSource(this.gameObject);
                    }
                    else
                    {
                        Beam_Dest = transform.forward;
                    }
                    Beam_Effect beam = Instantiate(Beam_Eff, transform);
                    beam.Shoot_Beam(Beam_Origin.position, Beam_Dest);
                }
            }
        }
	}
}
