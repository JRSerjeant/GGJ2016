using UnityEngine;
using System.Collections;

public class cogAniControl : MonoBehaviour {

    public string direction;

    // Update is called once per frame
    void Update () {

        switch (direction)
        {
            case "up":
                this.GetComponent<Animator>().Play("Cog_GoingUp");
                break;
            case "down":
                this.GetComponent<Animator>().Play("Cog_Falling");
                break;
            case "idle":
                this.GetComponent<Animator>().Play("Cog_Idle");
                break;
            default:
                this.GetComponent<Animator>().Play("Cog_Idle");
                break;
        }
    }
}
