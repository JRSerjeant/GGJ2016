using UnityEngine;
using System.Collections;

public class objectFactory : MonoBehaviour {

    public static GameObject pfb_Block;

    void Start()
    {
        pfb_Block = (GameObject)Resources.Load("Prefabs/Objects/pfb_Block");
    }

    public static void createBlock(Vector3 position)
    {
        GameObject newBlock = Instantiate(pfb_Block) as GameObject;
        newBlock.transform.position = new Vector3(position.x, position.y);
    }
}
