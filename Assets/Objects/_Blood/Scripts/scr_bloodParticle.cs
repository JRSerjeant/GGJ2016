using UnityEngine;
using System.Collections;

public class scr_bloodParticle : MonoBehaviour {

    ParticleSystem PS;
	// Use this for initialization
	void Start () {
        PS = GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!PS.IsAlive())
        {
            Destroy(gameObject);
        }
	
	}
}
