using System;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TimeControllerScript : MonoBehaviour
{

    private static readonly int _gameLengthSeconds = Configuration.GameLengthInSeconds;

    public static float timeRemaining = _gameLengthSeconds;

    public static bool IsGameOver { get { return timeRemaining <= 0.0f; } }

    private Text _textElement;
    public static float _startGameTime;

	//public AudioSource musicSource; 
	//public AudioClip SacrificialDrums;


    void Start()
    {
        _startGameTime = Time.time;
        _textElement = GetComponent<Text>();
    }

    void Update()
    {

		if (timeRemaining == 40)
		{
			//musicSource.pitch = (2);
			Completed.SoundManager.instance.RestartMusic();

		}

		if (timeRemaining <= 6)
		{
		//musicSource.pitch = (2);
		Completed.SoundManager.instance.SpeedUpMusic();

		}

		if (timeRemaining <= 0)
		{

			Completed.SoundManager.instance.StopMusic();

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
}
