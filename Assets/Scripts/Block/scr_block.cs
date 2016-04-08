using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class scr_block : MonoBehaviour {
    public int blockLife;

	// Use this for initialization
	void Start () {
        blockLife = Configuration.BlockLife;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (blockLife <= 0)
            Destroy(this.gameObject);
	}
    public void removeLife()
    {
        blockLife--;
    }
}
