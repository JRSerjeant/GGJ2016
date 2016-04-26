using UnityEngine;
using Assets.Scripts;
using System.Collections;

public class scr_LittleManGenerator : MonoBehaviour
{

    float lastFired;

    Vector3 redManStartPosition;
    Vector3 blueManStartPosition;

    public static bool lastWasRed;
    public static bool LastWasRed
    {
        set
        {
            lastWasRed = value;
        }
        get
        {
            return lastWasRed;
        }
    }

    public static bool lastWasBlue;
    public static bool LastWasBlue
    {
        set
        {
            lastWasBlue = value;
        }
        get
        {
            return lastWasBlue;
        }
    }


    // Use this for initialization
    void Start()
    {
        lastFired = 0.0f;
        LastWasBlue = false;
        LastWasRed = false;

        redManStartPosition = new Vector3(9f, -1.4f);
        blueManStartPosition = new Vector3(-9f, -1.4f);

    }

    // Update is called once per frame
    void Update()
    {
        if (!TimeControllerScript.IsGameOver)
        {
            if ((Time.time > lastFired + 1 / Configuration.PeoplePerSecond))
            {
                objectFactory.createlittleMan(redManStartPosition, Configuration.playerColourEnum.Red);
                objectFactory.createlittleMan(blueManStartPosition, Configuration.playerColourEnum.Blue);
                lastFired = Time.time;
            }
        }
    }
}
