using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wave_Spawner : MonoBehaviour
{
    public Transform StartLoc;
    public Transform EndLoc;

    //Eli Added this for Task Generation
    public Random_Enemy_Text txt;
    //Eli Added this to make the Lives counter Work
    public Lives_Tracker lives_track;
    public Prototype_Nav Guy;
    public int WaveSize;
    public float WaveRate;    //Eli Added this for the Set_Wave_Stats() function. Delay between enemies in seconds.
    public Text LivesText;
	private int round;
	public Text RoundText;

	//Zach added this for Background Music
	private FadingAudioSource music;
	public AudioClip shopMusic;
	public AudioClip battleMusic;
	public bool shopPlaying;
	public int waveLeft; //Amount of enemies left. Enemy_Damager.KillEnemy() decrements this amount

    private List<Prototype_Nav> currentWaveUnits = null;

    // Use this for initialization
    void Start()
    {
		round = 0;
		music = GameObject.Find ("Music Audio Source").GetComponent<FadingAudioSource> ();
        lives_track = gameObject.GetComponent<Lives_Tracker>();
		shopPlaying = false;
		music.Fade (shopMusic, 1f, true);
        currentWaveUnits = new List<Prototype_Nav>();
        //StartCoroutine(StartWave());
    }

	public void BeginWave()
	{
		StartCoroutine (StartWave ());
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

			//LIFE ALWAYS BEING LOST IMMEDIATELY IF FIRST ARGUMENT IS GONE
            if (enemy.Agent.remainingDistance != 0 && enemy.Agent.remainingDistance < .1f)
            {
				waveLeft--;
                currentWaveUnits.RemoveAt(i);
            }
        }

		if (!shopPlaying && waveLeft == 0) {
			EndWave ();
			shopPlaying = true;
			music.Fade (shopMusic, 1f, true);
		}

		RoundText.text = "Round " + round;

        //if (CurrentLives > 0)

        //else
          //  LivesText.text = "You Lose!";

    }

	private void EndWave()
	{
        txt.gameObject.GetComponent<Tower_Director>().End_Wave();
		shopPlaying = true;
		music.Fade (shopMusic, 1f, true);
		round++;
		//Automatically return to shop menu
	}

    private IEnumerator StartWave()
    {
		waveLeft = WaveSize;
		shopPlaying = false;
		music.Fade (battleMusic, 1f, true);
        for (int i = 0; i < WaveSize; i++)
        {
            Prototype_Nav enemy = Instantiate(Guy, StartLoc.position, StartLoc.rotation);
            enemy.lives = lives_track;
            txt.Get_Random_Pair(enemy.gameObject);
            enemy.StartWave(EndLoc.position);
            currentWaveUnits.Add(enemy);
            yield return new WaitForSeconds(2);
        }

    }

    public void Set_Wave_Stats(int num_Enemies, float rate)
    {
		round++;
        WaveSize = num_Enemies;
        WaveRate = rate;
    }
}
