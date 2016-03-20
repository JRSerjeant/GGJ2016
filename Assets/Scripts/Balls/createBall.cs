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
    private int ballForce; //Reference to ball force. 

    //This needs to be called when creating a new ball to get its direction 
    public void Initialize(string Direction)
    {
        direction = Direction;//Set local direction from Direction passed as parameter. 
    }

	// Use this for initialization
	void Start () {
        ballRigidbody2D = GetComponent<Rigidbody2D>(); //get the reference to Rigidbody2D of the ball.prefab
        ballForce = Configuration.ballForce; //Get the ball fore from the 
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //set direction if player is red
        if (direction == "Red")
            ballRigidbody2D.AddForce(new Vector2(-ballForce, 0));
        //set direction if player is blue
        if (direction == "Blue")
            ballRigidbody2D.AddForce(new Vector2(ballForce, 0));
	}

    //called when ball collieds with anotherObject
    void OnCollisionEnter2D(Collision2D otherObject)
    {
        //check if the object collied with has the tag of "block"
        if (otherObject.gameObject.tag == "block")
        {
            //destroy the block.
            Destroy(otherObject.gameObject);
            Destroy(this.gameObject);        }

        //check if the object collied with has the tag of "LittleMen"
        if (otherObject.gameObject.tag == "LittleMen")
        {
            //get random number between 0 and 6
            int r = Random.Range(0, 6);
            // if random number = 1 
            if(r == 1)
            {
                //detsroy the "LittleMen"
                Destroy(otherObject.gameObject);
            }
        }
    }
}
