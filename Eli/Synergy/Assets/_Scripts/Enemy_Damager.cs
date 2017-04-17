using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Damager : MonoBehaviour {

    public float health;
    public float speed;
    public float min_speed;
    public float synergy_timer;
    public Image healthBar;
    public GameObject Synergy_Particle;
    public Transform Particle_Loc;

    private float default_speed; //Don't know if needed yet
    private float default_timer; //Definitely needed
    private Queue<GameObject> sources;
    private Queue<GameObject> synergized_sources;
    private float healthMod;

	private UnityEngine.AI.NavMeshAgent navmesh;

	Wave_Spawner ws; //Zach

	// Use this for initialization
	void Start () {
		navmesh = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent> ();
        health = 100;
        default_speed = speed;
        default_timer = synergy_timer;
        sources = new Queue<GameObject>();
        synergized_sources = new Queue<GameObject>();
        healthMod = health; //set healthMod to health so if enemies have different starting healths their healthBar scales correctly when taking dmg.
		ws = GameObject.Find ("Spawn Logic").GetComponent<Wave_Spawner> ();
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
        if(source.GetComponent<Tower_Attack>().isAccountant)
        {
            GetComponent<Cash_On_Death>().extra_payout = true;
        }

        Tower_Attack tower = source.GetComponent<Tower_Attack>();
        Damage(tower.damage);
        Slow(tower.slow);
        StartCoroutine(DamageOverTime(tower.dot_damage, tower.dot_rate, tower.dot_length));
    }

    
    private void ApplySynergy(GameObject source)
    {
        if (source.GetComponent<Tower_Attack>().isAccountant)
        {
            GetComponent<Cash_On_Death>().extra_payout = true;
        }

        Tower_Attack tower = source.GetComponent<Tower_Attack>();
        if(tower.GetComponent<Tower_Economy>().Upgrade != 3)
        {
            Damage(tower.damage * 2);
            Slow(tower.slow * 2);
            StartCoroutine(DamageOverTime(tower.dot_damage * 1.5f, tower.dot_rate * 1.5f, tower.dot_length * 1.5f));
        }
        else
        {
            Damage(tower.damage * 3);
            Slow(tower.slow * 3);
            StartCoroutine(DamageOverTime(tower.dot_damage * 2.25f, tower.dot_rate * 2.25f, tower.dot_length * 2.25f));
        }
        Instantiate(Synergy_Particle, Particle_Loc);
    }

    private void Damage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / healthMod;
    }

    private void Slow(float slow)
    {
		StartCoroutine (SlowCo(slow));
    }

    private void KillEnemy()
    {
		ws.waveLeft--;
        StopAllCoroutines();
        Destroy(gameObject);
    }

	IEnumerator SlowCo(float slow)
    {
        bool slowed = false;

        if(navmesh.speed >= min_speed)
        {
            if(navmesh.speed - slow <= 0)
            {
                navmesh.speed = min_speed;
            }
            else
            {
                navmesh.speed -= slow;
            }
            slowed = true;
        }

        if(navmesh.speed < min_speed)
        {
            navmesh.speed = min_speed;
        }

		yield return new WaitForSeconds (3);
        if(slowed)
            navmesh.speed += slow;
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
