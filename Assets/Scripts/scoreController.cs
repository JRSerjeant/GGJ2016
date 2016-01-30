using UnityEngine;
using System.Collections;

public class scoreController : MonoBehaviour {
    private static int redPlayerScore;
    private static int bluePlayerScore;

    // Use this for initialization
    void Start () {
        redPlayerScore = 0;
        bluePlayerScore = 0;
        LogScores();
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

    private static void LogScores()
    {
        Debug.Log("Red: " + redPlayerScore);
        Debug.Log("Blue: " + bluePlayerScore);
    }

    public static void addRedPlayerScore()
    {
        redPlayerScore ++;
        LogScores();
    }
    public static void addBluePlayerScore()
    {
        bluePlayerScore++;
        LogScores();
    }
}
