using UnityEngine;
using System.Collections;
using Assets.Scripts;

//
// Description
//  This script is attached to ball.prefab to control it actions. createBall.cs is proberl;y not the best name. 
// 

public class createBall : MonoBehaviour {

    public Rigidbody2D ballRigidbody2D; //Rigidbody2D of the ball.prefab
    static string direction; //Used to set direction of the balls force
    private Quaternion rotation;
    private int ballForce; //Reference to ball force.
    private int ballLife; 

    //This needs to be called when creating a new ball to get its direction 
    public void Initialize(string Direction)
    {
        direction = Direction;//Set local direction from Direction passed as parameter. 
    }

	// Use this for initialization
	void Start () {
        ballRigidbody2D = GetComponent<Rigidbody2D>(); //get the reference to Rigidbody2D of the ball.prefab
        ballForce = Configuration.ballForce; //Get the ball fore from the 
        ballLife = Configuration.BallLife;

        //set direction if player is red
        if (direction == "Red")
            //ballRigidbody2D.velocity = new Vector2(-ballForce, 0);
 
        ballRigidbody2D.AddForce(- transform.right * ballForce);
        //set direction if player is blue
        if (direction == "Blue")
            //ballRigidbody2D.velocity = new Vector2(ballForce, 0);
            ballRigidbody2D.AddForce(transform.right * ballForce);
        StartCoroutine(DestroyBall());
        //Debug.Log("Ball Rotation: " + this.transform.eulerAngles);
        //Debug.Log("Ball ballRigidbody2D Rotation: " + ballRigidbody2D.rotation);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (ballLife <= 0)
            Destroy(this.gameObject);
        ////set direction if player is red
        //if (direction == "Red")
        //    //ballRigidbody2D.velocity = new Vector2(-ballForce, 0);
        //    ballRigidbody2D.AddForce(new Vector2(-ballForce, 0));
        ////set direction if player is blue
        //if (direction == "Blue")
        //    //ballRigidbody2D.velocity = new Vector2(ballForce, 0);
        //    ballRigidbody2D.AddForce(new Vector2(ballForce, 0));
    }

    //called when ball collieds with anotherObject
    void OnCollisionEnter2D(Collision2D otherObject)
    {

        //check if the object collied with has the tag of "block"
        if (otherObject.gameObject.tag == "block")
        {
            otherObject.gameObject.GetComponent<scr_block>().removeLife(); 
        }

        if (otherObject.gameObject.tag == "ground")
        {
            otherObject.gameObject.GetComponent<scr_ground>().GroundHP = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.tag == "LittleMen")
        {
            objectFactory.createbloodParticle(transform.position);
            Destroy(otherObject.gameObject);
        }
    }

        IEnumerator DestroyBall()
    {
        yield return new WaitForSeconds(3.5f);
        Destroy(this.gameObject);
    }
}
