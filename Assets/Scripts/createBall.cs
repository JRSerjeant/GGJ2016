using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class createBall : MonoBehaviour {
    public Rigidbody2D rb;
    static string direction;
    public static int numberofBalls;

    public void Initialize(string Direction)
    {
        direction = Direction;
    }
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        BallRepository.ConsumeRedBall();
        numberofBalls++;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (direction == "LEFT")
            //rb.velocity = new Vector2(-10, 0);
            rb.AddForce(new Vector2(-10, 0));
        if (direction == "RIGHT")
            rb.AddForce(new Vector2(10, 0));
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "block")
        {
            Destroy(coll.gameObject);
        }
        if(coll.gameObject.tag == "LittleMen")
        {
            int r = Random.Range(0, 6);
            Debug.Log(r);
            if(r == 1)
            {
                Destroy(coll.gameObject);
            }
        }

    }
    void OnDestroy()
    {
        numberofBalls--;
    }

}
