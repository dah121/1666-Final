using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Zach

public class Enemy_Damager : MonoBehaviour {

    public float health;
    public float speed;
    public float min_speed;
    public float synergy_timer;
    public Image healthBar;

    private float default_speed; //Don't know if needed yet
    private float default_timer; //Definitely needed
    private Queue<GameObject> sources;
    private Queue<GameObject> synergized_sources;
    private float healthMod;

	// Use this for initialization
	void Start () {
        health = 100;
        default_speed = speed;
        default_timer = synergy_timer;
        sources = new Queue<GameObject>();
        synergized_sources = new Queue<GameObject>();
        healthMod = health; //set healthMod to health so if enemies have different starting healths their healthBar scales correctly when taking dmg.
	}
	
	// Update is called once per frame
	void Update () {
        if(synergy_timer <= 0)
        {
            if(sources.Count > 1)
            {
                for(int i = 0; i < sources.Count; i++)
                {
                    synergized_sources.Enqueue(sources.Dequeue());
                }

                for(int i = 0; i < synergized_sources.Count; i++)
                {
                    ApplySynergy(synergized_sources.Dequeue());
                }
            }
            else if(sources.Count == 1)
            {
                Apply(sources.Dequeue());
            }

            synergy_timer = default_timer;
        }
        else
        {
            synergy_timer -= Time.deltaTime;
        }

        if(health <= 0)
        {
            KillEnemy();
        }
	}

    public void SendSource(GameObject source)
    {
        sources.Enqueue(source);
    }

    /** Weapon attributes from Tower-Attack
    public float damage;
    public float dot_rate; //rate as how many seconds between damage pulses
    public float dot_length; //length as # of damage pulses
    public float dot_damage;
    public float slow;
    **/
    private void Apply(GameObject source)
    {
        Tower_Attack tower = source.GetComponent<Tower_Attack>();
        Damage(tower.damage);
        Slow(tower.slow);
        StartCoroutine(DamageOverTime(tower.dot_damage, tower.dot_rate, tower.dot_length));
    }

    
    private void ApplySynergy(GameObject source)
    {
        KillEnemy(); //I used this to drastically show synergy, flesh out more
    }

    private void Damage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / healthMod;
    }

    private void Slow(float slow)
    {
        speed -= slow;
        if (speed < min_speed)
        {
            speed = min_speed;
        }
    }

    private void KillEnemy()
    {
		Wave_Spawner ws = GameObject.Find ("Spawn Logic").GetComponent<Wave_Spawner> ();
		ws.waveLeft--;
        StopAllCoroutines();
        Destroy(gameObject);
    }

    IEnumerator DamageOverTime(float damage, float rate, float length)
    {
        if(damage == 0 || length == 0)
        {
            yield break;
        }

        for(int i = 0; i < length; i++)
        {
            Damage(damage);
            yield return new WaitForSeconds(rate);
        }
    }
}
