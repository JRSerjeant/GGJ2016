using UnityEngine;
using System.Collections;

public class littleMenController : MonoBehaviour {
    public Rigidbody2D rb;
    public EdgeCollider2D col;
    bool isColWithSlope;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        isColWithSlope = false;
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        if (isColWithSlope == false)
        {
            rb.AddForce(new Vector2(-10, 0));
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "slope")
        {
            isColWithSlope = true;
            rb.AddForce(new Vector2(0, -10));
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
