using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class playerRedController : MonoBehaviour
{

    public int speed;
    public GameObject redTopArrow;
    public GameObject redSideArrow;
    public GameObject ball;
    public GameObject tower;
	public AudioClip Canon1;
	public AudioClip Canon2;
    // Use this for initialization
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TimeControllerScript.IsGameOver)
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
                if (redSideArrow.transform.position.y > 0.4f)
                {
                    redSideArrow.transform.position = new Vector2(redSideArrow.transform.position.x, 0.39f);
                }
            }
            if (Input.GetKey("down"))
            {
                redSideArrow.transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
                redSideArrow.transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
                if (redSideArrow.transform.position.y < -1.05f)
                {
                    redSideArrow.transform.position = new Vector2(redSideArrow.transform.position.x, -1.04f);
                }
            }
            if (Input.GetKeyDown(KeyCode.Keypad0))
            {
                if (!BallRepository.IsRedPlayerBallsMax)
                {
                    GameObject go = (GameObject)Instantiate(ball, transform.position, new Quaternion());
                    createBall ScriptReference = go.GetComponent<createBall>();
                    ScriptReference.Initialize("LEFT");
                    BallRepository.ConsumeBlueBall();
					//fire sound
					Completed.SoundManager.instance.RandomizeSfx (Canon2);
                }
            }
        }
    }
}
