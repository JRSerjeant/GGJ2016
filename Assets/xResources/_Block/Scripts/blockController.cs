using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

public class blockController : MonoBehaviour
{
    private int blockLimit;
    private List<GameObject> blocks;

    // Use this for initialization
    void Start()
    {
        blockLimit = Configuration.BlockLimit;
        blocks = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            if (blocks[i] == null)
                blocks.RemoveAt(i);
        }
    }   
    
    public void generateBlock(Vector3 pos)
    {
        if (blocks.Count + 1 < blockLimit || blocks == null)
        {
            blocks.Add(objectFactory.createBlock(pos));

        }

    }    
}
