using UnityEngine;
using System.Collections;

public class scr_Exit : MonoBehaviour {
    public enum exitSide { Left, Right };
    public exitSide mySide;

    private GameObject leftSide;
    private GameObject rightSide;
    private GameObject redPlayer;
    private GameObject bluePlayer;

    // Use this for initialization
    void Start () {
        leftSide = GameObject.FindGameObjectWithTag("LeftExit");
        rightSide = GameObject.FindGameObjectWithTag("RightExit");
        redPlayer = GameObject.FindGameObjectWithTag("RedPlayer");
        bluePlayer = GameObject.FindGameObjectWithTag("BluePlayer");

    }

    // Update is called once per frame
    void Update () {
        if(redPlayer.transform.position.x < leftSide.transform.position.x)
        {
            redPlayer.transform.position = rightSide.transform.position; 
        }
        if( bluePlayer.transform.position.x < leftSide.transform.position.x)
        {
            bluePlayer.transform.position = rightSide.transform.position;
        }
        if (redPlayer.transform.position.x > rightSide.transform.position.x)
        {
            redPlayer.transform.position = leftSide.transform.position;  
        }
        if (bluePlayer.transform.position.x > rightSide.transform.position.x)
        {
            bluePlayer.transform.position = leftSide.transform.position;
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position,0.25f);
    }
}
