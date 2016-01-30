using UnityEngine;
using System.Collections;

public class littleMenController : MonoBehaviour
{
    public Rigidbody2D rb;
    public EdgeCollider2D col;

    bool isColWithSlope;
    bool atEndPoint;

    public string direction;
    public string forplayer;
    public string state;

    private int collisionCount;


    Vector2 nw; //TODO: Rename 


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //direction = "";
        isColWithSlope = false;
        atEndPoint = false;
    }

    // Update is called once per frame
    void Update()
    {

    }


    void FixedUpdate()
    {
        if (direction == "L")
        {
            if (transform.position.x < 0.0f)
            {
                atEndPoint = true;
            }
            if (atEndPoint == true)
            {
                Destroy(gameObject);
            }
        }

        if (direction == "R")
        {
            if (transform.position.x > 0.0f)
            {
                atEndPoint = true;
            }
            if (atEndPoint == true)
            {
                Destroy(gameObject);
            }
        }

        if (direction == "L")
            nw = new Vector2(-1, 0);
        if (direction == "R")
            nw = new Vector2(1, 0);

        if (isColWithSlope == false)
        {
            rb.velocity = nw.normalized;
            //rb.AddForce(new Vector2(-10, 0));
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        collisionCount++;


        if (col.gameObject.name == "slopeEnd")
        {
            isColWithSlope = false;
        }

        if (col.gameObject.name == "slope")
        {

            if (direction == "L")
                nw = new Vector2(-1, 1);

            if (direction == "R")
                nw = new Vector2(1, 1);

            isColWithSlope = true;
            rb.velocity = nw.normalized;
            //rb.AddForce(new Vector2(0, 100));
        }
        /*if (col.gameObject.name == "slope")
        {
            Debug.Log("HELLO");
            isColWithSlope = true;
            rb.AddForce(new Vector2(0, 0));
            rb.isKinematic = true;
        }*/
    }

    void OnCollisionExit2D(Collision2D other)
    {
        collisionCount --;
        if(collisionCount == 0)
        {
            GetComponent<Rigidbody2D>().gravityScale = 10;
            //Physics2D.gravity = new Vector3(0, 10, 0);
        }
    }
}