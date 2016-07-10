using UnityEngine;
using System.Collections;

public class scr_groundHit : MonoBehaviour {

    Animator ani;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void playHitAnimation()
    {
        ani = GetComponent<Animator>();
        ani.Play("Ground_Hit");
    }
}
