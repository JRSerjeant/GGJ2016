using UnityEngine;
using System.Collections;

public class scr_SnakeCanon : MonoBehaviour
{
    public GameObject myCog;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        myCog.transform.position = transform.position;
        //float height = transform.position.y - -1.0f;
        //Debug.Log(height);
        //transform.rotation = transform.rotation * new Quaternion(0, 0, height, 0);
    }
}
