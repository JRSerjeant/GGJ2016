using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

public class scr_ground : MonoBehaviour {

    TextMesh tm;
    GameObject textHP;
    public List<GameObject> collidingManList;

    public enum groundState { Falling, Static };
    public groundState currentState;

    private int groundHP;
    public int GroundHP
    {
        get { return groundHP; }
        set
        {
            groundHP--;
            if(groundHP <= 0)
                disable();
        }

    }
    public int InitializeGroundHP
    {
        get { return groundHP; }
        set { groundHP = value; }
    }

    // Use this for initialization
    void Start () {
        collidingManList = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
        switch (currentState)
        {
            case groundState.Falling:
                this.transform.position += Vector3.down * Time.deltaTime;
                break;
            case groundState.Static:
                break;
            default:
                break;
        }
        //displayText();
    }
    public void displayText()
    {
        if( textHP == null)
        {
            textHP = Instantiate(objectFactory.pfb_DisplayTextNumber, this.transform.position, new Quaternion()) as GameObject;
        }
        tm = textHP.GetComponent<TextMesh>();
        tm.text = groundHP.ToString();
    }

    void disable()
    {
        Destroy(this.gameObject);
        foreach (var item in collidingManList)
        {
            if (item.gameObject != null)
            {
                objectFactory.createbloodParticle(item.gameObject.transform.position);
                Destroy(item.gameObject);
            }
        }
    }
}
