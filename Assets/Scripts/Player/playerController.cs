using UnityEngine;
using Assets.Scripts;
using System.Collections;

public class playerController : MonoBehaviour {

    public KeyCode moveRightKey;
    public KeyCode moveLeftKey;
    public KeyCode moveUpKey;
    public KeyCode moveDownKey;
    public KeyCode fireCannon;
    public KeyCode dropBlock;

    public GameObject myCannon;

    private int speed;

    // Use this for initialization
    void Start () {
        speed = Configuration.PlayerSpeed;
	}
	
	// Update is called once per frame
	void Update () {
	    
        if(Input.GetKey(moveLeftKey))
        {
            this.transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(moveRightKey))
        {
            this.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(moveUpKey))
        {
            //this.transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
            //TODO: Sort out how to stop cannons moving up to far now we only have one player controller script
            /*if (blueSideArrow.transform.position.y > 1.8f)
            {
                blueSideArrow.transform.position = new Vector2(blueSideArrow.transform.position.x, 1.79f);
            }*/
        }
        if (Input.GetKey(moveDownKey))
        {
            //this.transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
            //TODO: Sort out how to stop cannons moving up to far now we only have one player controller script
            /*if (blueSideArrow.transform.position.y < -1.05f)
            {
                blueSideArrow.transform.position = new Vector2(blueSideArrow.transform.position.x, -1.04f);
            }*/
        }
        if (Input.GetKeyDown(fireCannon))
        {
            //TODO: Add fire cannon 
            /*if (!BallRepository.IsBluePlayerBallsMax)
            {
                GameObject go = (GameObject)Instantiate(ball, transform.position, new Quaternion());
                createBall ScriptReference = go.GetComponent<createBall>();
                ScriptReference.Initialize("RIGHT");
                BallRepository.ConsumeBlueBall();
                Completed.SoundManager.instance.RandomizeSfx(Canon1, Canon2);
            }*/

        }

        if (Input.GetKeyDown(dropBlock))
        {
            if (!(this.transform.position.x > -0.70f && this.transform.position.x < 0.70f))
            {
                objectFactory.createBlock(this.transform.position);
                PlayBlockSound();
            }
        }
    }

    private void PlayBlockSound()
    {
        Completed.SoundManager.instance.RandomizeSfx(audioFactory.Create1, audioFactory.Create2, audioFactory.Create3);

    }
}
