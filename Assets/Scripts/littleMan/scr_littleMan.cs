using UnityEngine;
using Assets.Scripts;
using System.Collections;

public class scr_littleMan : MonoBehaviour {

    //Vector3 redManStartPosition;
    //Vector3 blueManStartPosition;

    float redEndPoint;
    float blueEndPoint;
    float redDirectionValue;
    float blueDirectionValue;
    public float directionValue;
    float gameHeight;

    public Sprite BlueSprite;
    public Sprite RedSprite;

    public Configuration.playerColourEnum manColour;

    public RuntimeAnimatorController manAnimation;
    //public RuntimeAnimatorController manBlueAnimation;
    //public RuntimeAnimatorController manRedAnimation;

    bool stateRunning;
    bool stateRaising;
    bool stateDead;
    bool stateColWithSlope;
    bool stateAtEndPoint;
    /*
    bool isRed;
    public bool IsRed
    {
        set
        {
            isRed = true;
        }
    }

    bool isBlue;
    public bool Isblue
    {
        set
        {
            isBlue = true;
        }
    } */



    // Use this for initialization
    void Awake() {
        //redManStartPosition = new Vector3(9f, -1.4f);
        //blueManStartPosition = new Vector3(-9f, -1.4f);
        gameHeight = 5.5f;
        redEndPoint = -0.1f;
        blueEndPoint = 0.1f;
        redDirectionValue = Configuration.menVelocity;
        blueDirectionValue = -Configuration.menVelocity;
        stateRunning = true;
        stateRaising = false;
        stateDead = false;
        this.GetComponent<SpriteRenderer>().sortingOrder = 0;

        //setManRedorBlue();
        
    }
    void Update()
    {
        //Stop men from rotating 
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

	void FixedUpdate () {

	    if(stateRunning)
        {
            //this.GetComponent<Rigidbody2D>().velocity = new Vector2(directionValue,0.0f);
            this.transform.position += new Vector3(directionValue, 0, 0) * Time.deltaTime;
        }
        if(stateRaising)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            this.transform.position += new Vector3(0, 10, 0) * Time.deltaTime;
        }
        if(this.transform.position.y > gameHeight)
        {
            addToScore();
            Destroy(gameObject);
        }
               
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "RaiseZone")
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
            stateRunning = false;
            stateRaising = true;
        }
        if (col.gameObject.name == "slope")
        {
            Debug.Log("Hello");
        }
    }

    public void Initialize(Configuration.playerColourEnum ManColour)
    {
        this.manColour = ManColour;

        switch (manColour)
        {
            case Configuration.playerColourEnum.Red:
                setManProperties(BlueSprite, blueDirectionValue);
                GetComponent<SpriteRenderer>().flipX = true;
                break;
            case Configuration.playerColourEnum.Blue:
                setManProperties(RedSprite, redDirectionValue);
                break;
            default:
                break;
        }
    }

    //void setManRedorBlue()
    //{
    //    if (!scr_LittleManGenerator.LastWasBlue)
    //    {
    //        //Isblue = true;

    //        //set up position,sprite,ani,etc
    //        setManProperties(BlueSprite,blueDirectionValue,manBlueAnimation);
            

    //        scr_LittleManGenerator.LastWasBlue = true;
    //        scr_LittleManGenerator.LastWasRed = false;
    //        return;
    //    }
    //    if (!scr_LittleManGenerator.LastWasRed)
    //    {
    //        //IsRed = true;

    //        //set up position,sprite,ani,etc
    //        setManProperties(RedSprite, redDirectionValue, manRedAnimation);

    //        scr_LittleManGenerator.LastWasRed = true;
    //        scr_LittleManGenerator.LastWasBlue = false;
    //        return;
    //    }
    //}

    void setManProperties(Sprite s, float d /*, RuntimeAnimatorController a*/)
    {
        //this.transform.position = p;
        this.GetComponent<SpriteRenderer>().sprite = s;
        //this.GetComponent<Animator>().runtimeAnimatorController = a;
        this.directionValue = d;
        
    }

    void addToScore()
    {
        //if(isBlue)
        //{
        //    scoreController.addBluePlayerScore();
        //}
        //if(isRed)
        //{
        //    scoreController.addRedPlayerScore();
        //}

    }

}
