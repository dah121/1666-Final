using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wave_Spawner : MonoBehaviour
{
    public Transform StartLoc;
    public Transform EndLoc;

    public Prototype_Nav Guy;
    public int WaveSize;
    public int CurrentLives;
    public Text LivesText;

    private List<Prototype_Nav> currentWaveUnits = null;

    // Use this for initialization
    void Start()
    {
        currentWaveUnits = new List<Prototype_Nav>();
        StartCoroutine(StartWave());
    }

    // Update is called once per frame
    void Update()
    {
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
        for (int i = 0; i < WaveSize; i++)
        {
            Prototype_Nav enemy = Instantiate(Guy, StartLoc.position, StartLoc.rotation);
            enemy.StartWave(EndLoc.position);
            currentWaveUnits.Add(enemy);
            yield return new WaitForSeconds(1);
        }

    }
}
