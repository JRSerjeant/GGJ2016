using UnityEngine;
using System.Collections;

public class playerRedController : MonoBehaviour {

    public int speed;
    public GameObject redTopArrow;
    public GameObject redSideArrow;
    public GameObject ball;
    // Use this for initialization
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("left"))
        {
            redTopArrow.transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey("right"))
        {
            redTopArrow.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey("up"))
        {
            redSideArrow.transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        }
        if (Input.GetKey("down"))
        {
            redSideArrow.transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject go = (GameObject)Instantiate(ball, transform.position, new Quaternion());
            createBall ScriptReference = go.GetComponent<createBall>();
            ScriptReference.Initialize("LEFT");
        }
    }
}
