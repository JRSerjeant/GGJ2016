using UnityEngine;
using System.Collections;

public class playerOneCreateLittleMen : MonoBehaviour
{
    public GameObject men;
    float lastFired;
    // Use this for initialization
    void Start()
    {
        lastFired = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time > lastFired + 1.0f))
        {
            GameObject go = (GameObject)Instantiate(men, new Vector2(8.0f, -1.41f), new Quaternion());
            littleMenController ScriptReference = go.GetComponent<littleMenController>();
            ScriptReference.direction = "L";
            ScriptReference.forplayer = "RED";
            lastFired = Time.time;
        }
    }
}
