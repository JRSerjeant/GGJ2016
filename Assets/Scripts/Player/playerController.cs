using UnityEngine;
using Assets.Scripts;
using System.Collections.Generic;
using System.Collections;

public class playerController : MonoBehaviour {

    public KeyCode moveRightKey;
    public KeyCode moveLeftKey;
    public KeyCode moveUpKey;
    public KeyCode moveDownKey;
    public KeyCode fireCannon;
    public KeyCode dropBlock;

    public enum playerColourEnum {Red,Blue};
    public playerColourEnum playerColour;


    public GameObject myCannon;
    private blockController blockController;

    private int speed;
       
    // Use this for initialization
    void Start () {
        speed = Configuration.PlayerSpeed;
        blockController = GetComponent<blockController>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(moveLeftKey))
        {
            this.transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(moveRightKey))
        {
            this.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(moveUpKey))
        {
            myCannon.transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
            if(myCannon.transform.position.y > 1.8f)
            {
                myCannon.transform.position = new Vector2(myCannon.transform.position.x, 1.79f);
            }
        }
        if (Input.GetKey(moveDownKey))
        {
            myCannon.transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
            if (myCannon.transform.position.y < -1.05f)
            {
                myCannon.transform.position = new Vector2(myCannon.transform.position.x, -1.04f);
            }
        }
        if (Input.GetKeyDown(fireCannon))
        {
            objectFactory.createBall(myCannon.transform.position, playerColour.ToString());
        }

        if (Input.GetKeyDown(dropBlock))
        {
            if (!(this.transform.position.x > -0.70f && this.transform.position.x < 0.70f))
            {
                blockController.generateBlock(this.transform.position);
            }
        }
    }
}
