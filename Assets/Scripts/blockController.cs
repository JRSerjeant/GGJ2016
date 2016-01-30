using UnityEngine;
using System.Collections;

public class blockController : MonoBehaviour {
    public GameObject block;
    public GameObject bluePlayerTop;
    public GameObject redPlayerTop;
    public int redPlayerBlockCount;
    public int bluePlayerBlockCount;
    public int blockCount;

    // Use this for initialization
    void Start () {
        blockCount = 10;
        redPlayerBlockCount = 0;
        bluePlayerBlockCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bluePlayerBlockCount < blockCount)
            {
                bluePlayerBlockCount ++;
                GameObject go = Instantiate(block, bluePlayerTop.GetComponent<Renderer>().transform.position, new Quaternion()) as GameObject;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            if (redPlayerBlockCount < blockCount)
            {
                redPlayerBlockCount ++;
                GameObject go = Instantiate(block, redPlayerTop.GetComponent<Renderer>().transform.position, new Quaternion()) as GameObject;
            }
        }
    }
}
