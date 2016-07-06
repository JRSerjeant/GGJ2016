using UnityEngine;
using System.Collections;

public class scr_BallExplode : MonoBehaviour {

    Animator ani;

	// Use this for initialization
	void Start () {
        ani = GetComponent<Animator>();
        ani.Play("Ball_Explode");
    }

    void Update()
    {
        
    }
}
