using UnityEngine;
using System.Collections;

public class objectFactory : MonoBehaviour
{

    public static GameObject pfb_Block;
    public static GameObject pfb_littleMan;
    public static GameObject pfb_Ball;
    public static GameObject pfb_Cog;
    public static GameObject pfb_bloodParticle;
    void Awake()
    {
        pfb_Block = (GameObject)Resources.Load("Prefabs/Objects/pfb_Block");
        pfb_littleMan = (GameObject)Resources.Load("Prefabs/Objects/pfb_littleMan");
        pfb_Ball = (GameObject)Resources.Load("Prefabs/Objects/Ball");
        pfb_Cog = (GameObject)Resources.Load("Prefabs/Players/pfb_Cog");
        pfb_bloodParticle = (GameObject)Resources.Load("Particles/pfb_bloodParticle");
    }

    void Start()
    {

    }

    public static GameObject createBlock(Vector3 position)
    {
        GameObject newBlock = Instantiate(pfb_Block) as GameObject;
        newBlock.transform.position = new Vector3(position.x, position.y);
        return newBlock;
    }

    public static void createBall(Vector3 position, string ballDirection, Quaternion rotation)
    {
        //Debug.Log("Reoation passed to create ball: " + rotation.eulerAngles);
        GameObject newBall = Instantiate(pfb_Ball,position, rotation) as GameObject;
        createBall createBallScriptReference = newBall.GetComponent<createBall>();
        createBallScriptReference.Initialize(ballDirection);
    }


    public static void createlittleMan()
    {
        GameObject newLittleMan = Instantiate(pfb_littleMan) as GameObject;
    }

    public static GameObject createCog()
    {
        GameObject obj_Cog = Instantiate(pfb_Cog) as GameObject;
        return obj_Cog;

    }
    public static void createbloodParticle(Vector3 position)
    {
        GameObject obj_bloodParticle = Instantiate(pfb_bloodParticle) as GameObject;
        obj_bloodParticle.transform.position = position;
        obj_bloodParticle.layer = 0;
    }
}