using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeControllerScript : MonoBehaviour
{

    private static readonly int _gameLengthSeconds = 60;

    public static float timeRemaining = _gameLengthSeconds;

    public static bool IsGameOver = timeRemaining <= 0;
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
            _textElement.text = Math.Max(timeRemaining, 0f).ToString("00");
        }
    }
}
