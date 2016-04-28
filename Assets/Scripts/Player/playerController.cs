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

    //public enum Configuration.playerColourEnum {Red,Blue};
    public Configuration.playerColourEnum playerColour;

    public scr_SnakeCanon SnakeCanon_Script;

    public GameObject myCog;
    public GameObject myCannon;
    private blockController blockController;

    private float myCannonRotationSpeed;

    private int speed;
       
    // Use this for initialization
    void Start () {
        speed = Configuration.PlayerSpeed;
        myCannonRotationSpeed = Configuration.CannonRotationSpeed;
        blockController = GetComponent<blockController>();
        myCog = objectFactory.createCog();

        switch (playerColour)
        {
            case Configuration.playerColourEnum.Red:
                myCog.transform.position = new Vector3(myCannon.transform.position.x + 0.088f, myCannon.transform.position.y + 0.03399998f);
                myCog.GetComponent<SpriteRenderer>().flipX = true;
                break;
            case Configuration.playerColourEnum.Blue:
                myCog.transform.position = new Vector3(myCannon.transform.position.x - 0.066f, myCannon.transform.position.y + 0.013f);
                break;
            default:
                break;
        }

    }
    void Update() {
        if (Input.GetKeyUp(moveUpKey))
        {
            switch(playerColour)
                {
                    case Configuration.playerColourEnum.Red:
                        objectFactory.createBall(new Vector2(myCannon.transform.position.x, myCannon.transform.position.y) , playerColour.ToString(), myCannon.transform.rotation);
                    Debug.Log("Cannon Rotation: " + myCannon.transform.eulerAngles);
                        break;
                    case Configuration.playerColourEnum.Blue:
                        objectFactory.createBall(new Vector2(myCannon.transform.position.x, myCannon.transform.position.y), playerColour.ToString(), myCannon.transform.rotation);
                    Debug.Log("Cannon Rotation: " + myCannon.transform.eulerAngles);
                    break;
                    default:
                    break;
            }
        }

        switch (playerColour)
        {
            case Configuration.playerColourEnum.Red:
                myCog.transform.position = new Vector3(myCannon.transform.position.x + 0.088f, myCannon.transform.position.y + 0.03399998f);
                break;
            case Configuration.playerColourEnum.Blue:
                myCog.transform.position = new Vector3(myCannon.transform.position.x - 0.066f, myCannon.transform.position.y + 0.013f);
                break;
            default:
                break;
        }
    }
	void FixedUpdate () {
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
            if (myCannon.transform.position.y > 1.6f)
            {
                myCannon.transform.position = new Vector2(myCannon.transform.position.x, 1.59f);
                
            }
            if(myCannon.transform.position != new Vector3(myCannon.transform.position.x, 1.59f))
            {
                switch (playerColour)
                {
                    case Configuration.playerColourEnum.Red:
                        myCannon.transform.Rotate(Vector3.back, Time.deltaTime * myCannonRotationSpeed);
                        break;
                    case Configuration.playerColourEnum.Blue:
                        myCannon.transform.Rotate(Vector3.forward, Time.deltaTime * myCannonRotationSpeed);
                        break;
                    default:
                        break;
                }                
                myCog.GetComponent<cogAniControl>().direction = "up";
            }
            

        }
        else if (myCannon.transform.position.y > -1.0f)
            //myCog.transform.position.y > -1.0f)
        {
            myCannon.transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
           
            myCog.GetComponent<cogAniControl>().direction = "down";

            switch (playerColour)
            {
                case Configuration.playerColourEnum.Red:
                    myCannon.transform.Rotate(Vector3.forward, Time.deltaTime * myCannonRotationSpeed);
                    break;
                case Configuration.playerColourEnum.Blue:
                    myCannon.transform.Rotate(Vector3.back, Time.deltaTime * myCannonRotationSpeed);
                    break;
                default:
                    break;
            }

        }

        if (myCannon.transform.position.y <= -1.0f)
        {
            myCannon.transform.rotation = new Quaternion(0, 0, 0, 0);
            myCog.GetComponent<cogAniControl>().direction = "";
        }




        //if (Input.GetKey(moveDownKey))
        //{
        //    myCannon.transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
        //    if (myCannon.transform.position.y < -1.05f)
        //    {
        //        myCannon.transform.position = new Vector2(myCannon.transform.position.x, -1.04f);
        //    }
        //    myCog.GetComponent<cogAniControl>().direction = "down";

        //}
        //if (!Input.GetKey(moveDownKey) && !Input.GetKey(moveUpKey))
        //{
        //    myCog.GetComponent<cogAniControl>().direction = "";
        //}


        //    if (Input.GetKeyDown(fireCannon))
        //{
        //    objectFactory.createBall(myCannon.transform.position, playerColour.ToString());
        //}

        if (Input.GetKeyDown(dropBlock))
        {
            if (!(this.transform.position.x > -0.70f && this.transform.position.x < 0.70f))
            {
                blockController.generateBlock(this.transform.position);
            }
        }
    }


}
