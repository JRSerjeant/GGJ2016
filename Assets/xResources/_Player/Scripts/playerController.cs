using UnityEngine;
using Assets.Scripts;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class playerController : MonoBehaviour {

    
    public KeyCode moveRightKey;
    public KeyCode moveLeftKey;
    private float axisLeftRight;

    public KeyCode moveUpKey;
    public KeyCode moveDownKey;

    public KeyCode joy_fireCannonButton;
    public KeyCode fireCannon;

    public KeyCode joy_dropBlockButton;
    public KeyCode dropBlock;

    //public enum Configuration.playerColourEnum {Red,Blue};
    public Configuration.playerColourEnum playerColour;

    public scr_SnakeCanon SnakeCanon_Script;

    public GameObject myCog;
    cogAniControl myCogScript;
    public GameObject myCannon;

    private float myCannonRotationSpeed;

    private int speed;
    private float lastTimeGroundCreated;

    private objectFactory scr_ObjectFactory;

    // Use this for initialization
    void Start () {
        scr_ObjectFactory = GameObject.FindGameObjectWithTag("ObjectFactory").GetComponent<objectFactory>();

        speed = Configuration.PlayerSpeed;
        myCannonRotationSpeed = Configuration.CannonRotationSpeed;

        myCog = scr_ObjectFactory.createCog();
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
        switch (playerColour)
        {
            case Configuration.playerColourEnum.Red:
                axisLeftRight = Input.GetAxis("RedHorizontal");
                break;
            case Configuration.playerColourEnum.Blue:
                axisLeftRight = Input.GetAxis("BlueHorizontal");
                break;
            default:
                break;
        }
        

        // Up [KEY UP] Fires a ball
        if (Input.GetKeyUp(moveUpKey) || Input.GetKeyUp(joy_fireCannonButton))
        {
            //Create a ball 
            switch(playerColour)
                {
                    case Configuration.playerColourEnum.Red:
                        scr_ObjectFactory.createBall(new Vector2(myCannon.transform.position.x, myCannon.transform.position.y) , playerColour.ToString(), myCannon.transform.rotation);
                        break;
                    case Configuration.playerColourEnum.Blue:
                    scr_ObjectFactory.createBall(new Vector2(myCannon.transform.position.x, myCannon.transform.position.y), playerColour.ToString(), myCannon.transform.rotation);
                    break;
                    default:
                    break;
            }
        }

        // UP [KEY PRESSED]
        if (Input.GetKey(moveUpKey) || Input.GetKey(joy_fireCannonButton))
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

        switch (playerColour)
        {
            case Configuration.playerColourEnum.Red:
                if (myCannon.transform.rotation.z >= 0.0f)
                {
                    myCogScript.direction = "idle";
                }
                break;
            case Configuration.playerColourEnum.Blue:
                 if (myCannon.transform.rotation.z <= 0.0f)
                        {
                            myCogScript.direction = "idle";
                        }
                break;
            default:
                break;
        }


       

        // LEFT [KEY PRESSED]
        if (Input.GetKey(moveLeftKey) || axisLeftRight == -1)
        {
            this.transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }

        // RIGHT [KEY PRESSED]
        if (Input.GetKey(moveRightKey) || axisLeftRight == 1)
        {
            this.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }

        // DOWN [KEY DOWN]
        if (Input.GetKeyDown(dropBlock) || Input.GetKeyDown(joy_dropBlockButton))
        {
            if (!(this.transform.position.x > -0.70f && this.transform.position.x < 0.70f))
            {

                if (lastTimeGroundCreated + 0.25f <= Time.fixedTime)
                {
                    lastTimeGroundCreated = Time.fixedTime;
                    GameObject go = Instantiate(scr_ObjectFactory.pfb_ground) as GameObject;

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
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton7))
        {
            SceneManager.LoadScene(0);
        }
    }
}
