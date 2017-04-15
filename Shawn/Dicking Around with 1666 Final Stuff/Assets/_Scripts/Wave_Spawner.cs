using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wave_Spawner : MonoBehaviour
{
    public Transform StartLoc;
    public Transform EndLoc;
    //public Prototype_Nav Enemy0;
    //public Prototype_Nav Enemy1;
    public Prototype_Nav[] EnemyTypes = new Prototype_Nav[2];

    public Text LivesText;

    public int CurrentLives;
    public int[] WaveSizes;
    public int[] Enemies;

    private int WaveIndex;
    private int EnemyIndex;
    private List<Prototype_Nav> currentWaveUnits = null;

    private bool x;

    // Use this for initialization
    public void Start()
    {
        WaveSizes = new int[] { 3, 4, 5 };
        WaveIndex = 0;

        //Enemies.Size MUST EQUAL sum(WaveSizes)
        Enemies = new int[] { 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1 };
        EnemyIndex = 0;

        CurrentLives = 5;
        currentWaveUnits = new List<Prototype_Nav>();

        x = true;
    }

    public void Launch()
    {
        StartCoroutine(StartWave());
    }

    // Update is called once per frame
    void Update()
    {
        if (x)
        {
            x = false;
            return;
        }
        for (int i = currentWaveUnits.Count - 1; i >= 0; i--)
        {
            Prototype_Nav enemy = currentWaveUnits[i];
            if (enemy == null)
            {
                currentWaveUnits.RemoveAt(i);
                continue;
            }

            if (enemy.Agent.remainingDistance < .1f)
            {
                Destroy(enemy.gameObject);
                currentWaveUnits.RemoveAt(i);
                Debug.Log("Enemy died");
                CurrentLives--;
            }
        }

        if (CurrentLives > 0)
            LivesText.text = "Lives: " + CurrentLives;
        else
            LivesText.text = "You Lose!";

    }

    private IEnumerator StartWave()
    {
        if (WaveIndex == WaveSizes.Length)
        {
            LivesText.text = "You Win!";
        }
        else
        {
            Debug.Log(WaveSizes[WaveIndex]);

            for (int i = 0; i < WaveSizes[WaveIndex++]; i++)
            {
                Debug.Log("EIndex: " + EnemyIndex);
                Debug.Log("Chosen: " + Enemies[EnemyIndex]);
                //Debug.Log("Ene")
                Prototype_Nav enemy = Instantiate(EnemyTypes[Enemies[EnemyIndex++]], StartLoc.position, StartLoc.rotation);
                if (enemy)
                {
                    Debug.Log("Enemy spawned");
                }
                enemy.StartWave(EndLoc.position);
                currentWaveUnits.Add(enemy);
                yield return new WaitForSeconds(2);
            }

        }

    }
}
