using UnityEngine;
using Assets.Scripts;
using System.Collections;

public class scr_SnakeCanon : MonoBehaviour
{
    public GameObject myCog;
    // Use this for initialization
    void Start()
    {
        myCog = objectFactory.createCog();
        myCog.transform.position = new Vector3(transform.position.x,transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        myCog.transform.position = new Vector3(transform.position.x, transform.position.y);
    }
}
