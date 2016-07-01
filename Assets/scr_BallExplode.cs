using UnityEngine;
using System.Collections;

public class scr_BallExplode : MonoBehaviour {

    Animation ani;

	// Use this for initialization
	void Start () {
        ani.wrapMode = WrapMode.Once;
        ani.Play("Ball_Explode");
    }

    void Update()
    {
        if( ! ani.isPlaying)
        {
            Destroy(gameObject);
        }

    }
}
