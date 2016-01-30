using UnityEngine;
using System.Collections;

public class blockController : MonoBehaviour {
    public GameObject block;
    public GameObject bluePlayerTop;
    public GameObject redPlayerTop;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = Instantiate(block,bluePlayerTop.GetComponent<Renderer>().transform.position , new Quaternion()) as GameObject;
        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            GameObject go = Instantiate(block, redPlayerTop.GetComponent<Renderer>().transform.position, new Quaternion()) as GameObject;
        }
    }
}
