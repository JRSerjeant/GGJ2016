using UnityEngine;
using System.Collections;

public class scr_BallExplode : MonoBehaviour {

    Animator ani;
    public AudioSource Audio_Source;

	// Use this for initialization
	void Start () {
        ani = GetComponent<Animator>();
        ani.Play("Ball_Explode");
        Audio_Source.Play();
    }

    void Update()
    {
        
    }
}
