using UnityEngine;
using Assets.Scripts;
using System.Collections;

public class scr_littleMan : MonoBehaviour {

    float redDirectionValue;
    float blueDirectionValue;
    public Vector3 running;
    public Vector3 climbing;
    float gameHeight;
    public Vector3 rotation;

    public Sprite BlueSprite;
    public Sprite RedSprite;

    public Configuration.playerColourEnum manColour;

    public RuntimeAnimatorController manAnimation;

    public enum manState{Running,Raising,Falling,Climbing,Flying,Dead,ColWithSlope,AtEndPoint,Manual};
    public  manState currentState;

    GameObject frontCollider;
    GameObject backCollider;
    Renderer manRenderer;
    Rigidbody2D manRigidbody2D;


    // Use this for initialization
    void Awake() {
        rotation = new Vector3(0, 0, 0);
        gameHeight = 5.5f;
        redDirectionValue = Configuration.menVelocity;
        blueDirectionValue = -Configuration.menVelocity;
        running = new Vector3(0.2f,0.0f);
        climbing = new Vector3(0.0f, 0.2f);
        currentState = manState.Running;
        this.GetComponent<SpriteRenderer>().sortingOrder = 0;
        manRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        frontCollider = Instantiate(objectFactory.pdf_ManMiniCollider) as GameObject;
        //frontCollider.GetComponent<BoxCollider2D>().isTrigger = true;
        frontCollider.GetComponent<scr_manMiniCollider>().Initialize(this.gameObject);

        backCollider = Instantiate(objectFactory.pdf_ManMiniCollider) as GameObject;
        //backCollider.GetComponent<BoxCollider2D>().isTrigger = true;
        backCollider.GetComponent<scr_manMiniCollider>().Initialize(this.gameObject);

        manRenderer = GetComponent<Renderer>();
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


    void Update()
    {

        UpdateRotation(rotation);
        SetMiniManMiniColliderPOsitions();
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
                break;
            case manState.Climbing:
                manRigidbody2D.isKinematic = true;
                this.transform.position += climbing * Time.deltaTime;
                rotation = new Vector3(0, 0, 0);
                break;
            case manState.Dead:
                break;
            case manState.ColWithSlope:
                //this.GetComponent<Rigidbody2D>().velocity = new Vector2(directionValue, 0.0f);
                this.transform.position += running * Time.deltaTime;
                rotation = new Vector3(0, 0, 45);
                break;
            case manState.AtEndPoint:
                break;
            default:
                break;
        }
        if(this.transform.position.y > gameHeight)
        {
            //addToScore();
            Destroy(gameObject);
        }

        
        
                
               
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.name == "RaiseZone")
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
            currentState = manState.Raising;
        }
        if (col.gameObject.name == "slope")
        {
            currentState = manState.ColWithSlope;
        }
    }

    void setManProperties(Sprite s, float d /*, RuntimeAnimatorController a*/)
    {

        this.GetComponent<SpriteRenderer>().sprite = s;
        running.x = d;
    }

    void UpdateRotation(Vector3 rot)
    {
        transform.rotation = Quaternion.Euler(rot);
    }

    void SetMiniManMiniColliderPOsitions()
    {
        switch (manColour)
        {
            case Configuration.playerColourEnum.Red:
                {
                    frontCollider.transform.position = new Vector3(transform.position.x + (manRenderer.bounds.size.x / 2), transform.position.y);
                    backCollider.transform.position = new Vector3(transform.position.x - (manRenderer.bounds.size.x / 2), transform.position.y);
                    break;
                }
            case Configuration.playerColourEnum.Blue:
                {
                    frontCollider.transform.position = new Vector3(transform.position.x - (manRenderer.bounds.size.x / 2), transform.position.y);
                    backCollider.transform.position = new Vector3(transform.position.x + (manRenderer.bounds.size.x / 2), transform.position.y);
                }
                break;
            default:
                break;
        }

    }
}
