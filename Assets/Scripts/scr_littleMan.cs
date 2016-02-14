using UnityEngine;
using System.Collections;

public class scr_littleMan : MonoBehaviour {

    Vector3 redManStartPosition;
    Vector3 blueManStartPosition;

    float redDirectionValue;
    float blueDirectionValue;
    float directionValue;


    public Sprite BlueSprite;
    public Sprite RedSprite;

    bool stateRunning;
    bool stateRaising;
    bool stateDead;
    bool stateColWithSlope;
    bool stateAtEndPoint;



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
    } 



    // Use this for initialization
    void Awake() {
        redManStartPosition = new Vector3(10f, -1.4f);
        blueManStartPosition = new Vector3(-10f, -1.4f);
        redDirectionValue = 2.0f;
        blueDirectionValue = 2.0f;
        stateRunning = true;
        stateRaising = false;
        stateDead = false;

        setManRedorBlue();
        
    }
	

	void FixedUpdate () {
	    if(stateRunning)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(directionValue,0.0f);
        }
	}

    void setManRedorBlue()
    {
        if (!scr_LittleManGenerator.LastWasBlue)
        {
            Isblue = true;

            //set up position,sprite,ani,etc
            setManProperties(blueManStartPosition,BlueSprite,blueDirectionValue);
            

            scr_LittleManGenerator.LastWasBlue = true;
            scr_LittleManGenerator.LastWasRed = false;
            return;
        }
        if (!scr_LittleManGenerator.LastWasRed)
        {
            IsRed = true;

            //set up position,sprite,ani,etc
            setManProperties(redManStartPosition, RedSprite, redDirectionValue);

            scr_LittleManGenerator.LastWasRed = true;
            scr_LittleManGenerator.LastWasBlue = false;
            return;
        }
    }

    void setManProperties(Vector2 p, Sprite s, float d)
    {
        this.transform.position = p;
        this.GetComponent<SpriteRenderer>().sprite = s;
        directionValue = d;
    }

}
