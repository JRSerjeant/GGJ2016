using UnityEngine;
using System.Collections;

public class cogAniControl : MonoBehaviour {

    public string direction;
    Quaternion rotation;
    Quaternion fixedRotation;
    //private float zRotation = 0.0f;

    //void Awake()
    //{
    //    Quaternion fixedRotation = transform.localRotation;
    //}

    // Update is called once per frame
    void Update () {
        

        switch (direction)
        {
            case "up":
                this.GetComponent<Animator>().Play("Snake Canon Up");
                break;
            case "down":
                this.GetComponent<Animator>().Play("Snake Canon Down");
                break;
            default:
                this.GetComponent<Animator>().Play("New State");
                break;
        }

        //transform.rotation = Quaternion.Euler(0, 0, zRotation);

    }
    void LateUpdate()
    {
        //transform.localRotation = fixedRotation;
    }



}
