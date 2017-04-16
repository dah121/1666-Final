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
    public Prototype_Nav Guy;
    public int WaveSize;
    public int CurrentLives;
    public Text LivesText;

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
		music = GameObject.Find ("Music Audio Source").GetComponent<FadingAudioSource> ();
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
                Destroy(enemy.gameObject);
                currentWaveUnits.RemoveAt(i);
                CurrentLives--;
            }
        }

		if (!shopPlaying && waveLeft == 0) {
			EndWave ();
			shopPlaying = true;
			music.Fade (shopMusic, 1f, true);
		}

        if (CurrentLives > 0)
            LivesText.text = "Lives: " + CurrentLives;
        else
            LivesText.text = "You Lose!";

    }

	private void EndWave()
	{
		shopPlaying = true;
		music.Fade (shopMusic, 1f, true);

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
            txt.Get_Random_Pair(enemy.gameObject);
            enemy.StartWave(EndLoc.position);
            currentWaveUnits.Add(enemy);
            yield return new WaitForSeconds(2);
        }

    }
}
