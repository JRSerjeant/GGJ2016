using UnityEngine;
using System.Collections;

public class scr_manGroundCollider : MonoBehaviour {

    GameObject obj_myLittleMan;
    scr_littleMan scr_myLittleMan;

    public int colCount;

    // Use this for initialization
    void Start () {
        colCount = 0;
	}

    public void Initialize(GameObject MyLittleMan)
    {
        obj_myLittleMan = MyLittleMan;
        scr_myLittleMan = obj_myLittleMan.GetComponent<scr_littleMan>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (colCount == 0)
        {
            if (scr_myLittleMan.currentState != scr_littleMan.manState.Climbing)
            {
                if (scr_myLittleMan.allowFalling == true)
                {
                    scr_myLittleMan.currentState = scr_littleMan.manState.Falling;
                }
                else
                {
                    scr_myLittleMan.currentState = scr_littleMan.manState.Running;
                }
            }
        }
        if(scr_myLittleMan.currentState == scr_littleMan.manState.Falling && colCount >= 1)
        {
            scr_myLittleMan.currentState = scr_littleMan.manState.Running;
            scr_myLittleMan.setIsKinematicFalse();
        }
    }

    void OnTriggerEnter2D(Collider2D otherObject)
    {
        //Debug.Log("OnTriggerStay2D");
        if (otherObject.gameObject.tag == "ground")
        {
            colCount++;
        }
    }

    void OnTriggerExit2D(Collider2D otherObject)
    {
        //Debug.Log("OnTriggerExit2D");
        if (otherObject.gameObject.tag == "ground")
        {
            colCount--;
        }
    }
}
