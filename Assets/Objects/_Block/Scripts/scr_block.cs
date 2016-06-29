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
	void Update () {
        if (blockLife <= 0)
            StartCoroutine(DestroyBlock());
	}
    public void removeLife()
    {
        blockLife--;
    }
    IEnumerator DestroyBlock()
    {
        yield return 0;
        Destroy(this.gameObject);
    }
}
