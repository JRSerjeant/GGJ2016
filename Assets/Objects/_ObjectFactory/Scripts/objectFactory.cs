﻿using UnityEngine;
using Assets.Scripts;
using System.Collections;

public class objectFactory : MonoBehaviour
{

    public GameObject pfb_Block;
    public GameObject pfb_ground;
    public GameObject pfb_littleMan;
    public GameObject pdf_ManMiniCollider;
    public GameObject pdf_ManGroundCollider;
    public GameObject pfb_Ball;
    public GameObject pfb_Cog;
    public GameObject pfb_bloodParticle;
    public GameObject pfb_DisplayTextNumber;

    void Awake()
    {
        //pfb_Block = (GameObject)Resources.Load("_Block/Prefabs/pfb_Block");
        //pfb_ground = (GameObject)Resources.Load("_Ground/Prefabs/pfb_ground");
        //pfb_littleMan = (GameObject)Resources.Load("_LittleMen/Prefabs/pfb_littleMan");
        //pdf_ManMiniCollider = (GameObject)Resources.Load("_LittleMen/Prefabs/pdf_ManMiniCollider");
        //pdf_ManGroundCollider = (GameObject)Resources.Load("_LittleMen/Prefabs/pdf_ManGroundCollider");
        //pfb_Ball = (GameObject)Resources.Load("_Ball/Prefabs/Ball");
        //pfb_Cog = (GameObject)Resources.Load("_Cog/Prefabs/pfb_Cog");
        //pfb_bloodParticle = (GameObject)Resources.Load("_Blood/Prefabs/pfb_bloodParticle");
        //pfb_DisplayTextNumber = (GameObject)Resources.Load("_DisplayTextNumber/Prefabs/pfb_DisplayTextNumber");
    }

    void Start()
    {

    }

    public GameObject createBlock(Vector3 position)
    {
        GameObject newBlock = Instantiate(pfb_Block) as GameObject;
        newBlock.transform.position = new Vector3(position.x, position.y);
        return newBlock;
    }

    public void createBall(Vector3 position, string ballDirection, Quaternion rotation)
    {
        //Debug.Log("Reoation passed to create ball: " + rotation.eulerAngles);
        GameObject newBall = Instantiate(pfb_Ball,position, rotation) as GameObject;
        createBall createBallScriptReference = newBall.GetComponent<createBall>();
        createBallScriptReference.Initialize(ballDirection);
    }


    public void createlittleMan(Vector3 Position, Configuration.playerColourEnum manColour)
    {
        GameObject newLittleMan = Instantiate(pfb_littleMan,Position,new Quaternion()) as GameObject;
        newLittleMan.GetComponent<scr_littleMan>().Initialize(manColour);
    }

    public GameObject createCog()
    {
        GameObject obj_Cog = Instantiate(pfb_Cog) as GameObject;
        return obj_Cog;

    }
    public void createbloodParticle(Vector3 position)
    {
        GameObject obj_bloodParticle = Instantiate(pfb_bloodParticle) as GameObject;
        obj_bloodParticle.transform.position = position;
        obj_bloodParticle.layer = 0;
    }
}