using UnityEngine;
using System.Collections;

public class playerOneCreateLittleMen : MonoBehaviour
{
    public GameObject men;
    public Sprite manRedSprites;
    public Animation manRedAnimation;

    float lastFired;
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
            if ((Time.time > lastFired + 1.0f))
            {
                GameObject go = (GameObject) Instantiate(men, new Vector2(10f, -1.4f), new Quaternion());
                littleMenController ScriptReference = go.GetComponent<littleMenController>();

                ScriptReference.direction = "L";
                ScriptReference.forplayer = "RED";
                //ScriptReference.GetComponent<SpriteRenderer>().sprite = manRedSprites;
                ScriptReference.GetComponent<Animator>().Play("charsetRedanim");


                //gameObject.GetComponent<SpriteRenderer>().sprite = manRedSprites;
                lastFired = Time.time;
            }
        }
    }
}
