using UnityEngine;
using Assets.Scripts;
using System.Collections;

public class scr_littleMan : MonoBehaviour {
    private objectFactory scr_ObjectFactory;

    float redDirectionValue;
    float blueDirectionValue;

    public EdgeCollider2D slopeObject;
    private bool passedTop;

    public float runningSpeed;
    public float slopeRunningSpeed;
    public float fallingSpeed;
    public float climbingSpeed;

    Vector3 running;
    Vector3 runningSlope;
    Vector3 climbing;
    Vector3 falling;

    public Vector3 rotation;
    private Vector3 myRotation;
    private Vector3 blueClimbRotation;
    private Vector3 redClimbRotation;

    ScoreManager scoreText;

    public bool allowFalling;
    public bool isGrounded;
    public int colTrggerCount;

    public Sprite BlueSprite;
    public Sprite RedSprite;

    public Configuration.playerColourEnum manColour;

    public RuntimeAnimatorController manAnimation;

    public enum manState{Running,Raising,Falling,Climbing,Flying,Dead,ColWithSlope,AtEndPoint,Manual};
    public  manState currentState;

    GameObject frontCollider;
    GameObject backCollider;
    GameObject groundCollider;
    Renderer manRenderer;

    // Use this for initialization
    void Awake() {
        scr_ObjectFactory = GameObject.FindGameObjectWithTag("ObjectFactory").GetComponent<objectFactory>();

        scoreText = GameObject.FindGameObjectWithTag("scoreText").GetComponent<ScoreManager>();
        passedTop = false;
        rotation = new Vector3(0, 0, 0);
        blueClimbRotation = new Vector3(0, 0, 0);
        redClimbRotation = new Vector3(0, 0, 0);
        isGrounded = true;
        allowFalling = true;
        colTrggerCount = 0;
        redDirectionValue = runningSpeed;
        blueDirectionValue = -runningSpeed;
        running = new Vector3(runningSpeed,0.0f);
        runningSlope = new Vector3(slopeRunningSpeed, slopeRunningSpeed);
        climbing = new Vector3(0.0f, climbingSpeed);
        falling = new Vector3(0.0f, -climbingSpeed);
        currentState = manState.Running;
        //directionValue = 10.0f;

        //frontCollider = Instantiate(objectFactory.pdf_ManMiniCollider) as GameObject;
        //frontCollider.GetComponent<BoxCollider2D>().isTrigger = true;
        //frontCollider.GetComponent<scr_manMiniCollider>().Initialize(this.gameObject);
        groundCollider = Instantiate(scr_ObjectFactory.pdf_ManGroundCollider) as GameObject;
        groundCollider.GetComponent<scr_manGroundCollider>().Initialize(this.gameObject);


        backCollider = Instantiate(scr_ObjectFactory.pdf_ManMiniCollider) as GameObject;
        backCollider.GetComponent<scr_manMiniCollider>().Initialize(this.gameObject);


        manRenderer = GetComponent<Renderer>();
    }

    void Start()
    {
        
        
    }

    public void Initialize(Configuration.playerColourEnum ManColour)
    {
        this.manColour = ManColour;

        switch (manColour)
        {
            case Configuration.playerColourEnum.Red:
                setManProperties(BlueSprite, blueDirectionValue, blueClimbRotation);
                GetComponent<SpriteRenderer>().flipX = true;
                break;
            case Configuration.playerColourEnum.Blue:
                setManProperties(RedSprite, redDirectionValue, redClimbRotation);
                break;
            default:
                break;
        }
    }


    void Update()
    {

        UpdateRotation(rotation);
        if (currentState != manState.ColWithSlope)
        {
            SetExtraColliderPositions();
        }
        

    }

    void FixedUpdate () {

        switch (currentState)
        {
            case manState.Manual:
                break;
            case manState.Running:
                //manRigidbody2D.isKinematic = false;
                this.transform.position += running * Time.deltaTime;
                rotation = new Vector3(0, 0, 0);
                break;
            case manState.Raising:
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
                this.transform.position += new Vector3(0, 10, 0) * Time.deltaTime;
                break;
            case manState.Flying:
                break;
            case manState.Falling:
                //manRigidbody2D.isKinematic = true;
                this.transform.position += falling * Time.deltaTime;
                rotation = new Vector3(0, 0, 0);
                break;
            case manState.Climbing:
                //manRigidbody2D.isKinematic = true;
                this.transform.position += climbing * Time.deltaTime;
                rotation = new Vector3(0, 0, 0);
                break;
            case manState.Dead:
                break;
            case manState.ColWithSlope:
                //this.GetComponent<Rigidbody2D>().velocity = new Vector2(directionValue, 0.0f);
                //manRigidbody2D.isKinematic = true;
                //Debug.Log("Coll with SLope");
                Destroy(backCollider);
                Destroy(groundCollider);
                //this.transform.position += runningSlope * Time.deltaTime;

                if (!passedTop)
                {
                    this.transform.position = Vector2.MoveTowards(this.transform.position, slopeObject.points[1], climbingSpeed * Time.deltaTime);
                    if(new Vector2(this.transform.position.x, this.transform.position.y) == slopeObject.points[1])
                    {
                        passedTop = true;
                    }
                }
                if(passedTop)
                {
                    this.transform.position = Vector2.MoveTowards(this.transform.position, slopeObject.points[2], runningSpeed * Time.deltaTime);
                    if (new Vector2(this.transform.position.x, this.transform.position.y) == slopeObject.points[2])
                    {
                        scr_ObjectFactory.createbloodParticle(transform.position);
                        switch (manColour)
                        {
                            case Configuration.playerColourEnum.Red:
                                scoreText.RedScore++;
                                break;
                            case Configuration.playerColourEnum.Blue:
                                scoreText.BlueScore++;
                                break;
                            default:
                                break;
                        }
                        Destroy(gameObject);
                    }
                }


                rotation = myRotation;
                break;
            case manState.AtEndPoint:
                break;
            default:
                break;
        }             
	}


    void OnDestroy()
    {
        Destroy(backCollider);
        Destroy(groundCollider);
    }

    void OnCollisionEnter2D(Collision2D otherObject)
    {
        
        if (otherObject.gameObject.name == "RaiseZone")
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
            currentState = manState.Raising;
        }
    }

    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.name == "slope" || otherObject.gameObject.name == "slope 1")
        {
            // Debug.Log(otherObject.gameObject.GetComponent<EdgeCollider2D>().points[1] + " " + manColour);
            slopeObject = otherObject.gameObject.GetComponent<EdgeCollider2D>();
            currentState = manState.ColWithSlope;
        }
        if (otherObject.gameObject.tag == "ground")
        {
            scr_ground groundScript = otherObject.gameObject.GetComponent<scr_ground>();
            if (groundScript.currentState == scr_ground.groundState.Falling)
            {
                Destroy(gameObject);
            }
        }
    }

    void setManProperties(Sprite s, float d , Vector3 r)
    {

        this.GetComponent<SpriteRenderer>().sprite = s;
        running.x = d;
        myRotation = r;
    }

    void UpdateRotation(Vector3 rot)
    {
        transform.rotation = Quaternion.Euler(rot);
    }

    void SetExtraColliderPositions()
    {
        switch (manColour)
        {
            case Configuration.playerColourEnum.Red:
                {
                    //frontCollider.transform.position = new Vector3(transform.position.x + (manRenderer.bounds.size.x / 2), transform.position.y);
                    backCollider.transform.position = new Vector3(transform.position.x - (manRenderer.bounds.size.x / 2), transform.position.y);
                    break;
                }
            case Configuration.playerColourEnum.Blue:
                {
                    //frontCollider.transform.position = new Vector3(transform.position.x - (manRenderer.bounds.size.x / 2), transform.position.y);
                    backCollider.transform.position = new Vector3(transform.position.x + (manRenderer.bounds.size.x / 2), transform.position.y);
                }
                break;
            default:
                break;
        }
        groundCollider.transform.position = new Vector3(transform.position.x, transform.position.y - (manRenderer.bounds.size.y / 2));

    }

    //public void setIsKinematicFalse()
    //{
    //    manRigidbody2D.isKinematic = false;
    //}

    public void allowFallingTrue()
    {
        allowFalling = true;
    }
    public void allowFallingFalse()
    {
        allowFalling = false;
    }
}
