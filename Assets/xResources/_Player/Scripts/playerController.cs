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
    cogAniControl myCogScript;
    public GameObject myCannon;
    private blockController blockController;

    private float myCannonRotationSpeed;

    private int speed;
    private float lastTimeGroundCreated;

       
    // Use this for initialization
    void Start () {
        speed = Configuration.PlayerSpeed;
        myCannonRotationSpeed = Configuration.CannonRotationSpeed;
        blockController = GetComponent<blockController>();

        myCog = objectFactory.createCog();
        myCogScript = myCog.GetComponent<cogAniControl>();

        lastTimeGroundCreated = Time.fixedTime;

        switch (playerColour)
        {
            case Configuration.playerColourEnum.Red:
                myCog.transform.position = new Vector3(myCannon.transform.position.x, myCannon.transform.position.y);
                myCog.GetComponent<SpriteRenderer>().flipX = true;
                break;
            case Configuration.playerColourEnum.Blue:
                myCog.transform.position = new Vector3(myCannon.transform.position.x, myCannon.transform.position.y);
                break;
            default:
                break;
        }

    }
    void Update() {

        // Up [KEY UP] Fires a ball
        if (Input.GetKeyUp(moveUpKey))
        {
            //Create a ball 
            switch(playerColour)
                {
                    case Configuration.playerColourEnum.Red:
                        objectFactory.createBall(new Vector2(myCannon.transform.position.x, myCannon.transform.position.y) , playerColour.ToString(), myCannon.transform.rotation);
                        break;
                    case Configuration.playerColourEnum.Blue:
                        objectFactory.createBall(new Vector2(myCannon.transform.position.x, myCannon.transform.position.y), playerColour.ToString(), myCannon.transform.rotation);
                    break;
                    default:
                    break;
            }
        }

        // UP [KEY PRESSED]
        if (Input.GetKey(moveUpKey))
        {
            switch (playerColour)
            {
                case Configuration.playerColourEnum.Red:
                    myCannon.transform.Rotate(Vector3.back, Time.deltaTime * myCannonRotationSpeed);
                    myCogScript.direction = "up";
                    break;
                case Configuration.playerColourEnum.Blue:
                    myCannon.transform.Rotate(Vector3.forward, Time.deltaTime * myCannonRotationSpeed);
                    myCogScript.direction = "up";
                    break;
                default:
                    break;
            }
        }
        else if (myCannon.transform.rotation.z != 0.0f)
        {
            switch (playerColour)
            {
                case Configuration.playerColourEnum.Red:
                    if (myCannon.transform.rotation.z < 0.0f)
                    {
                        myCannon.transform.Rotate(Vector3.forward, Time.deltaTime * myCannonRotationSpeed);
                        myCogScript.direction = "down";
                    }
                    break;
                case Configuration.playerColourEnum.Blue:
                    if (myCannon.transform.rotation.z > 0.0f)
                    {
                        myCannon.transform.Rotate(Vector3.back, Time.deltaTime * myCannonRotationSpeed);
                        myCogScript.direction = "down";
                    }
                    break;
                default:
                    break;
            }
        }
        if (myCannon.transform.rotation.z <= 0.0f)
        {
            myCogScript.direction = "idle";
        }

            // LEFT [KEY PRESSED]
            if (Input.GetKey(moveLeftKey))
            {
                this.transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
            }

        // RIGHT [KEY PRESSED]
        if (Input.GetKey(moveRightKey))
        {
            this.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }

        // DOWN [KEY DOWN]
        if (Input.GetKeyDown(dropBlock))
        {
            if (!(this.transform.position.x > -0.70f && this.transform.position.x < 0.70f))
            {

                if (lastTimeGroundCreated + 0.25f <= Time.fixedTime)
                {
                    lastTimeGroundCreated = Time.fixedTime;
                    GameObject go = Instantiate(objectFactory.pfb_ground) as GameObject;

                    Transform t = go.GetComponent<Transform>();
                    t.position = transform.position;


                    BoxCollider2D bc2d = go.GetComponent<BoxCollider2D>();
                    bc2d.isTrigger = true;

                    scr_ground scr = go.GetComponent<scr_ground>();
                    scr.currentState = scr_ground.groundState.Falling;
                    //blockController.generateBlock(this.transform.position);
                }
            }
        }
    }
}
