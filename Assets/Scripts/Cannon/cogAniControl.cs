using UnityEngine;
using System.Collections;

public class cogAniControl : MonoBehaviour {

    public string direction;


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
}
