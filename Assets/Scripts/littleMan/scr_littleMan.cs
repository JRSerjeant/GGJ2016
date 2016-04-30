using UnityEngine;
using Assets.Scripts;
using System.Collections;

public class scr_littleMan : MonoBehaviour {

    float redDirectionValue;
    float blueDirectionValue;
    public float directionValueX;
    public float directionValueY;
    public float directionValueZ;
    float gameHeight;
    public Vector3 rotation;

    public Sprite BlueSprite;
    public Sprite RedSprite;

    public Configuration.playerColourEnum manColour;

    public RuntimeAnimatorController manAnimation;


    public enum manState{Running,Raising,Falling,Climbing,Flying,Dead,ColWithSlope,AtEndPoint};
    public  manState currentState;





    // Use this for initialization
    void Awake() {
        rotation = new Vector3(0, 0, 0);
        gameHeight = 5.5f;
        redDirectionValue = Configuration.menVelocity;
        blueDirectionValue = -Configuration.menVelocity;
        directionValueY = 0.0f;
        directionValueZ = 0.0f;
        currentState = manState.Running;
        this.GetComponent<SpriteRenderer>().sortingOrder = 0;
        
    }
    void Update()
    {
        UpdateRotation(rotation);
        
    }

	void FixedUpdate () {

        switch (currentState)
        {
            case manState.Running:
                this.transform.position += new Vector3(directionValueX, directionValueY, directionValueZ) * Time.deltaTime;
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
                break;
            case manState.Dead:
                break;
            case manState.ColWithSlope:
                //this.GetComponent<Rigidbody2D>().velocity = new Vector2(directionValue, 0.0f);
                this.transform.position += new Vector3(directionValueX, directionValueX * 2, 0) * Time.deltaTime;
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

    void setManProperties(Sprite s, float d /*, RuntimeAnimatorController a*/)
    {

        this.GetComponent<SpriteRenderer>().sprite = s;

        this.directionValueX = d;
        
    }

    void UpdateRotation(Vector3 rot)
    {
        transform.rotation = Quaternion.Euler(rot);
    }

}
