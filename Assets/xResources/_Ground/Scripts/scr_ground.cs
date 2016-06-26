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

    Collider2D collider;

    public enum groundState { Falling, Static };
    public groundState currentState;

    

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
        collidingManList = new List<GameObject>();
        collider = GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update () {

        switch (currentState)
        {
            case groundState.Falling:
                gameObject.layer = 2;
                this.transform.position += Vector3.down * Time.deltaTime;
                RayStartLocation = new Vector2(transform.position.x, transform.position.y - (collider.bounds.size.y / 2));
                collider.enabled = false;
                hit = Physics2D.Raycast(RayStartLocation, Vector2.down);
                RayObject = hit.transform.gameObject;
                RayDistance = hit.distance;
                collider.enabled = true;
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

                this.transform.position = new Vector3(RayObject.transform.position.x, RayObject.transform.position.y + collider.bounds.size.y);

                currentState = groundState.Static;
                collider.isTrigger = false;
            }
        }
    }

    public void displayText()
    {
        if( textHP == null)
        {
            textHP = Instantiate(objectFactory.pfb_DisplayTextNumber, this.transform.position, new Quaternion()) as GameObject;
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
                objectFactory.createbloodParticle(item.gameObject.transform.position);
                Destroy(item.gameObject);
            } 
        }
        collidingManList.RemoveAll(x => x == null);
    }
}
