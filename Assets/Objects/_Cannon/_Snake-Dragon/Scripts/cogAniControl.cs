using UnityEngine;
using System.Collections;

public class cogAniControl : MonoBehaviour {

    public string direction;
    public AudioSource Audio_cogUpGrind;
    public AudioSource Audio_cogDownSparks;
    // Update is called once per frame
    void Update () {

        switch (direction)
        {
            case "up":
                //Audio_cogDownSparks.Stop();
                //if (!Audio_cogUpGrind.isPlaying)
                //{
                //    Audio_cogUpGrind.Play();
                //}
                this.GetComponent<Animator>().Play("Cog_GoingUp");
                break;
            case "down":
                //Audio_cogUpGrind.Stop();
                //if (!Audio_cogDownSparks.isPlaying)
                //{
                //    Audio_cogDownSparks.Play();
                //}
                this.GetComponent<Animator>().Play("Cog_Falling");
                break;
            case "idle":
                //Audio_cogDownSparks.Stop();
                //Audio_cogUpGrind.Stop();
                this.GetComponent<Animator>().Play("Cog_Idle");
                break;
            default:
                this.GetComponent<Animator>().Play("Cog_Idle");
                break;
        }
    }
}
