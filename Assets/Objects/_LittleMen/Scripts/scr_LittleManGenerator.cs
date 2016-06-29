using UnityEngine;
using Assets.Scripts;
using System.Collections;

public class scr_LittleManGenerator : MonoBehaviour
{
    private objectFactory scr_ObjectFactory;

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
        scr_ObjectFactory = GameObject.FindGameObjectWithTag("ObjectFactory").GetComponent<objectFactory>();

        lastFired = 0.0f;
        LastWasBlue = false;
        LastWasRed = false;

        redManStartPosition = new Vector3(9.5f, -1.334f);
        blueManStartPosition = new Vector3(-9.5f, -1.334f);

    }

    // Update is called once per frame
    void Update()
    {
            if ((Time.time > lastFired + 1 / Configuration.PeoplePerSecond))
            {
                scr_ObjectFactory.createlittleMan(redManStartPosition, Configuration.playerColourEnum.Red);
                scr_ObjectFactory.createlittleMan(blueManStartPosition, Configuration.playerColourEnum.Blue);
                lastFired = Time.time;
            }
    }
}
