using UnityEngine;
using System.Collections;

public class playerBlueController : MonoBehaviour {
    public int speed;

    public GameObject blueTopArrow;
    public GameObject blueSideArrow;
    public GameObject ball;

    public static Vector3 poistionTop;

    // Use this for initialization
    void Start () {
        speed = 5;
	}
	
	// Update is called once per frame
	void Update () {

	    if (!TimeControllerScript.IsGameOver)
	    {
	        if (Input.GetKey("a"))
	        {
	            blueTopArrow.transform.position += new Vector3(-speed, 0, 0)*Time.deltaTime;
	        }
	        if (Input.GetKey("d"))
	        {
	            blueTopArrow.transform.position += new Vector3(speed, 0, 0)*Time.deltaTime;
	        }
	        if (Input.GetKey("w"))
	        {
	            blueSideArrow.transform.position += new Vector3(0, speed, 0)*Time.deltaTime;
	        }
	        if (Input.GetKey("s"))
	        {
	            blueSideArrow.transform.position += new Vector3(0, -speed, 0)*Time.deltaTime;
	        }
	        if (Input.GetKeyDown(KeyCode.Keypad0))
	        {
	            GameObject go = (GameObject)Instantiate(ball, transform.position, new Quaternion());
	            createBall ScriptReference = go.GetComponent<createBall>();
	            ScriptReference.Initialize("RIGHT");
	        }
	    }
    }
}
