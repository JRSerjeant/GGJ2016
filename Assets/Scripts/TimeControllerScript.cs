using System;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class TimeControllerScript : MonoBehaviour
{

    private static readonly int _gameLengthSeconds = Configuration.GameLengthInSeconds;

    public static float timeRemaining = _gameLengthSeconds;

    public static bool IsGameOver { get { return timeRemaining <= 0.0f; } }

    private Text _textElement;
    private float _startGameTime;


    void Start()
    {
        _startGameTime = Time.time;
        _textElement = GetComponent<Text>();
    }

    void Update()
    {
        timeRemaining = _gameLengthSeconds - Time.time - _startGameTime;

        if (!IsGameOver)
        {
            _textElement.text = "TIME REMAINING " + Math.Max(timeRemaining, 0f).ToString("00");
        }
        else
        {
            _textElement.text = "GAME OVER";
        }
    }
}
