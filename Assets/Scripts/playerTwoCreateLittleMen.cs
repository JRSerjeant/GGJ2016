using UnityEngine;
using System.Collections;

public class playerTwoCreateLittleMen : MonoBehaviour
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
            GameObject go = Instantiate(men, new Vector2(-10f, -1.41f), new Quaternion()) as GameObject;
            littleMenController ScriptReference = go.GetComponent<littleMenController>();
            ScriptReference.direction = "R";

            //var bur =  go.GetComponent<>


            //GameObject go = (GameObject)Instantiate(prefab, Vector3.zero, Quaternion.identity);
            //SomeComponent comp = go.GetComponent<SomeComponent>();
            //comp.property1 = "blah";
            //comp.property2 = 2;

            //newMan.direction = "L";
            lastFired = Time.time;
        }
    }
}