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
    public float RayDistance;

    public enum groundState { Falling, Static };
    public groundState currentState;
    private objectFactory scr_ObjectFactory;

    public float fallSpeed;
    Vector3 fallDirection;

    private int groundHP;
    public int GroundHP
    {
        get { return groundHP; }
        set
        {
            groundHP--;
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
                RayStartLocation = new Vector2(transform.position.x, transform.position.y - (GetComponent<BoxCollider2D>().bounds.size.y / 2));
                GetComponent<BoxCollider2D>().enabled = false;
                hit = Physics2D.Raycast(RayStartLocation, Vector2.down);
                RayObject = hit.transform.gameObject;
                RayDistance = hit.distance;
                GetComponent<BoxCollider2D>().enabled = true;
                this.transform.position = new Vector3 (RayObject.transform.position.x, this.transform.position.y);

                break;
            case groundState.Static:
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
                gameObject.layer = 0;

                this.transform.position = new Vector3(RayObject.transform.position.x, RayObject.transform.position.y + GetComponent<BoxCollider2D>().bounds.size.y);

                currentState = groundState.Static;
                GetComponent<BoxCollider2D>().isTrigger = false;
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
        Destroy(this.gameObject);
        foreach (var item in collidingManList)
        {
            if (item.gameObject != null)
            {
                scr_ObjectFactory.createbloodParticle(item.gameObject.transform.position);
                Destroy(item.gameObject);
            } 
        }
        collidingManList.RemoveAll(x => x == null);
    }
}
