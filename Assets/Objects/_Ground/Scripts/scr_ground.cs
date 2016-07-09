using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

public class scr_ground : MonoBehaviour {

    TextMesh tm;
    GameObject textHP;
    public List<GameObject> collidingManList;

    public RaycastHit2D  hit;
    Vector2 RayStartLocation;
    public GameObject RayObject;

    public AudioSource createSFX;
    public AudioSource thudSFX;
    public AudioSource squashSFX;

    SpriteRenderer sprite;

    public enum groundState { Falling, Static };
    public groundState currentState;
    private objectFactory scr_ObjectFactory;
    public Vector2 position;
    public float fallSpeed;
    Vector3 fallDirection;

    public bool indestructible;

    private int groundHP;
    public int GroundHP
    {
        get { return groundHP; }
        set
        {
            groundHP--;
            if(!indestructible)
                if(groundHP <= 0)
                    disable();
        }

    }
    public int InitializeGroundHP
    {
        get { return groundHP; }
        set { groundHP = value; }
    }

    // Use this for initialization
    void Start () {
        sprite = GetComponent<SpriteRenderer>();
        scr_ObjectFactory = GameObject.FindGameObjectWithTag("ObjectFactory").GetComponent<objectFactory>();
        collidingManList = new List<GameObject>();
        fallDirection = new Vector3(0, -fallSpeed, 0);

    }
	
	// Update is called once per frame
	void Update () {

        switch (currentState)
        {
            case groundState.Falling:
                gameObject.layer = 2;
                this.transform.position += fallDirection * Time.deltaTime;
                RayStartLocation = new Vector2(transform.position.x, transform.position.y);
                GetComponent<BoxCollider2D>().enabled = false;
                hit = Physics2D.Raycast(RayStartLocation, Vector2.down);
                RayObject = hit.transform.gameObject;
                GetComponent<BoxCollider2D>().enabled = true;
                this.transform.position = new Vector3 (RayObject.transform.position.x, this.transform.position.y);
                break;
            case groundState.Static:
                collidingManList.RemoveAll(x => x == null);
                break;
            default:
                break;
        }
        //displayText();
    }

    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (currentState == groundState.Falling)
        {
            if (otherObject.gameObject == RayObject)
            {
                currentState = groundState.Static;
                gameObject.layer = 0;
                this.transform.position = new Vector3(RayObject.transform.position.x, RayObject.transform.position.y + GetComponent<BoxCollider2D>().bounds.size.y);
                GetComponent<BoxCollider2D>().isTrigger = false;
            }

            if (otherObject.tag == "LittleMen")
            {
                squashSFX.Play();
            }
        }

    }

    public void displayText()
    {
        if( textHP == null)
        {
            textHP = Instantiate(scr_ObjectFactory.pfb_DisplayTextNumber, this.transform.position, new Quaternion()) as GameObject;
        }
        tm = textHP.GetComponent<TextMesh>();
        tm.text = groundHP.ToString();
    }

    void disable()
    {
        SetAboveFalling();
        foreach (var item in collidingManList)
        {
            if (item.gameObject != null)
            {
                scr_ObjectFactory.createbloodParticle(item.gameObject.transform.position);
                squashSFX.Play();
                Destroy(item.gameObject);
            } 
        }
        Destroy(this.gameObject);
        
    }

    public void SetStateFalling()
    {
        Debug.Log("SetStateFalling()");
        currentState = groundState.Falling;
        GetComponent<BoxCollider2D>().isTrigger = true;
        SetAboveFalling();
        //UnityEditor.EditorApplication.isPaused = true;
    }

    public void SetAboveFalling()
    {
        RayStartLocation = new Vector2(transform.position.x, transform.position.y);
        GetComponent<BoxCollider2D>().enabled = false;
        hit = Physics2D.Raycast(RayStartLocation, Vector2.up);
        GetComponent<BoxCollider2D>().enabled = true;

        if (hit.transform.gameObject.tag == "ground")
        {
            hit.transform.gameObject.GetComponent<scr_ground>().SetStateFalling();
            Debug.Log(hit.transform.gameObject.GetComponent<scr_ground>().currentState);
        }

    }
}
