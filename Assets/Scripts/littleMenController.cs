﻿using UnityEngine;
using System.Collections;

public class littleMenController : MonoBehaviour
{
    public Rigidbody2D rb;
    public EdgeCollider2D col;

    bool isColWithSlope;
    bool atEndPoint;

    Vector2 nw;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isColWithSlope = false;
        atEndPoint = false;
    }

    // Update is called once per frame
    void Update()
    {

    }


    void FixedUpdate()
    {
        if (transform.position.x < 0.0f)
        {
            Debug.Log(transform.position.x);
            atEndPoint = true;
        }
        if (atEndPoint == true)
        {
            Debug.Log("Should Destroy");
            Destroy(gameObject);
        }

        nw = new Vector2(-1, 0);

        if (isColWithSlope == false)
        {
            rb.velocity = nw.normalized;
            //rb.AddForce(new Vector2(-10, 0));
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "slopeEnd")
        {
            isColWithSlope = false;
        }

        if (col.gameObject.name == "slope")
        {
            Debug.Log("HELLO");
            nw = new Vector2(-1, 1);
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
}