using UnityEngine;
using System.Collections;

public class createBall : MonoBehaviour {
    public Rigidbody2D rb;
    static string direction;

    public void Initialize(string Direction)
    {
        direction = Direction;
    }
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (direction == "LEFT")
            rb.AddForce(new Vector2(10, 0));
        if (direction == "RIGHT")
            rb.AddForce(new Vector2(-10, 0));
	}
}
