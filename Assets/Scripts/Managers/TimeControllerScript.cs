using System;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TimeControllerScript : MonoBehaviour
{
	//public AudioClip Drum;
	//public AudioClip Gong;

	public float LoadTime = 1.5f;

    private static readonly int _gameLengthSeconds = Configuration.GameLengthInSeconds;

    public static float timeRemaining = _gameLengthSeconds;

    public static bool IsGameOver { get { return timeRemaining <= 0.0f; } }

    private Text _textElement;
    public static float _startGameTime;

	public static int TimesPlayed = 0;
	 
	//public AudioClip SacrificialDrums;


    void Start()
    {
		//TimesPlayed = 0;
        _startGameTime = Time.time;
        _textElement = GetComponent<Text>();
    }

    void Update()
    {
		
		//if (timeRemaining == 40)
		//{

			//Completed.SoundManager.instance.RestartMusic();

		//}

		if (timeRemaining == _gameLengthSeconds)
		{
			//Completed.SoundManager.instance.PlaySingle (audioFactory.Drum);
			//Completed.SoundManager.instance.PlaySingle (Drum);
			//Completed.SoundManager.instance.musicSource.time = (LoadTime);
			//Completed.SoundManager.instance.RestartMusic();
			TimesPlayed = 0;

			//Completed.SoundManager.instance.musicSource.volume = (0);
			//Completed.SoundManager.instance.musicSource.Play ();
			//Completed.SoundManager.instance.realmusicSource.Play ();

		}

		if (timeRemaining < 5.5)
		{
			//Completed.SoundManager.instance.PlaySingle (audioFactory.Drum);
			//Completed.SoundManager.instance.PlaySingle (Drum);
		//Completed.SoundManager.instance.musicSource.Play ();
		//Completed.SoundManager.instance.musicSource.volume = (1);

		//Completed.SoundManager.instance.SpeedUpMusic();
		//Completed.SoundManager.instance.musicSource.volume = (1);
		}

		if (timeRemaining < 0.5)
		{

			//Completed.SoundManager.instance.StopMusic();
			TimesPlayed = (TimesPlayed + 1);
			//add gong sound.
			PlayGongSound();

		}

        timeRemaining = _gameLengthSeconds - (Time.time - _startGameTime);

        if (!IsGameOver)
        {
            _textElement.text = Math.Max(timeRemaining, 0f).ToString("00");
        }
        else
        {
			
            string winText = "";
            if (scoreController.BluePlayerScore > scoreController.RedPlayerScore)
            {
                winText = "BLUE WINS!";
            }
            if (scoreController.RedPlayerScore> scoreController.BluePlayerScore)
            {
                winText = "RED WINS!";
            }
            else
            {
                winText = "DRAW!";
            }

            _textElement.text = "GAME OVER:\n " + winText;





            // // doesn't do anything
            foreach (var go in GameObject.FindGameObjectsWithTag("LittleMen"))
            {
                var component = go.GetComponent<Rigidbody2D>();
                component.isKinematic = true;
            }
        }
    }

	void PlayGongSound()
	{



		if (TimesPlayed == 1 & !IsGameOver)  //and gameover = false?
		{

			//Completed.SoundManager.instance.RandomizeSfx(audioFactory.Gong);
			//TimesPlayed = (TimesPlayed + 1);
			//TimesPlayed = 0;
			//audioFactory.Gong.
			//Completed.SoundManager.instance.musicSource.Play

		}


	}
}
