using UnityEngine;
using System.Collections;

public class cogAniControl : MonoBehaviour {

    public string direction;
    Quaternion rotation;
    Vector3 vRotation;

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
    }
    void LateUpdate()
    {
        //if (transform.rotation != Quaternion.Euler(0, 0, 0))
        //{
        //    transform.rotation = Quaternion.Euler(0, 0, 0);
        //}
    }
}
