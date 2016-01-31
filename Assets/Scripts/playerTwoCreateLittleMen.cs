using UnityEngine;
using System.Collections;

public class playerTwoCreateLittleMen : MonoBehaviour
{
    public GameObject men;
    float lastFired;
    public Sprite manBlueSprites;
    public RuntimeAnimatorController manBlueAnimation;

    // Use this for initialization
    void Start()
    {
        lastFired = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TimeControllerScript.IsGameOver)
        {
            if ((Time.time > lastFired + 0.2f))
            {
                GameObject go = Instantiate(men, new Vector2(-10f, -1.4f), new Quaternion()) as GameObject;
                littleMenController ScriptReference = go.GetComponent<littleMenController>();
                ScriptReference.direction = "R";
                ScriptReference.forplayer = "BLUE";
                ScriptReference.GetComponent<Animator>().runtimeAnimatorController = manBlueAnimation;
                lastFired = Time.time;
            }
        }

    }
}