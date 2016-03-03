using UnityEngine;
using System.Collections;

public class objectFactory : MonoBehaviour
{

    public static GameObject pfb_Block;
    public static GameObject pfb_littleMan;


    void Start()
    {
        pfb_Block = (GameObject)Resources.Load("Prefabs/Objects/pfb_Block");
        pfb_littleMan = (GameObject)Resources.Load("Prefabs/Objects/pfb_littleMan");
    }

    public static GameObject createBlock(Vector3 position)
    {
        GameObject newBlock = Instantiate(pfb_Block) as GameObject;
        newBlock.transform.position = new Vector3(position.x, position.y);
        return newBlock;
    }

    public static void createlittleMan()
    {
        GameObject newLittleMan = Instantiate(pfb_littleMan) as GameObject;
    }
}