﻿using UnityEngine;
using System.Collections;

public class littleMenController : MonoBehaviour
{
    public Rigidbody2D rb;
    public EdgeCollider2D col;

    public Sprite manBlueSprites;
    public Sprite manRedSprites;

    bool isColWithSlope;
    bool atEndPoint;

    public string direction;
    public string forplayer;
    public string state;

    private int collisionCount;


    Vector2 manVelocity; //TODO: Rename 


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //direction = "";
        isColWithSlope = false;
        atEndPoint = false;

        if(forplayer == "RED")
            gameObject.GetComponent<SpriteRenderer>().sprite = manRedSprites;
        if(forplayer == "BLUE")
            gameObject.GetComponent<SpriteRenderer>().sprite = manBlueSprites;

        state = "running";
    }

    // Update is called once per frame
    void Update()
    {

    }


    void FixedUpdate()
    {
        if (direction == "L" && state == "running")
        {
            manVelocity = new Vector2(-1, 0);
            //If man has reached the top of the tower
            if (transform.position.x < 0.0f)
            {
                atEndPoint = true;
            }
            if (atEndPoint == true)
            {
                state = "raise";
            }
        }

        if (direction == "R" && state == "running")
        {
            manVelocity = new Vector2(1, 0);
            //If man has reached the top of the tower
            if (transform.position.x > 0.0f)
            {
                atEndPoint = true;
            }
            if (atEndPoint == true)
            {
                state = "raise";
            }
        }

        /*if (direction == "L")
            manVelocity = new Vector2(-1, 0);
        if (direction == "R")
            manVelocity = new Vector2(1, 0);*/

        if (isColWithSlope == false)
        {
            rb.velocity = manVelocity.normalized;
            //rb.AddForce(new Vector2(-10, 0));
        }
        if(state == "raise")
        {
            raiseToHeaven();
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
                manVelocity = new Vector2(-1, 1);

            if (direction == "R")
                manVelocity = new Vector2(1, 1);

            isColWithSlope = true;
            rb.velocity = manVelocity.normalized;
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

    void raiseToHeaven()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
        transform.position += new Vector3(0, 10, 0) * Time.deltaTime;
        manVelocity = new Vector2(0, 1);
    }
}