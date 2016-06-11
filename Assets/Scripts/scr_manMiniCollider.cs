using UnityEngine;
using Assets.Scripts;
using System.Collections;

public class scr_manMiniCollider : MonoBehaviour
{
    GameObject obj_lastCollidedGround;
    GameObject obj_myLittleMan;
    scr_littleMan scr_myLittleMan;
    BoxCollider2D collider;
    public BoxCollider2D obj_lastCollidedGroundBoxCollider2D;
    public bool isColliding;
    public bool hasStoppedColliding;
    public int colCount;

    // Use this for initialization
    void Start()
    {
        collider = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStoppedColliding)
        {
            StartCoroutine(setIsKinematic());
        }
    }

    public void Initialize(GameObject MyLittleMan)
    {
        obj_myLittleMan = MyLittleMan;
        scr_myLittleMan = obj_myLittleMan.GetComponent<scr_littleMan>();
    }

    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.tag != "LittleMen")
        {
            //Debug.Log("Col with: " + otherObject.gameObject.name);
           
            if (otherObject.gameObject.tag == "ground")
            {   
                isColliding = true;
                colCount++;
                if (otherObject.transform.position.y > obj_myLittleMan.transform.position.y)
                {
                    scr_myLittleMan.currentState = scr_littleMan.manState.Climbing;
                }
            }
        }
    }
    void OnTriggerExit2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.tag != "LittleMan")
        {
            
            if (otherObject.gameObject.tag == "ground")
            {
                colCount--;
                if (colCount == 0)
                {
                    scr_myLittleMan.currentState = scr_littleMan.manState.Running;
                    hasStoppedColliding = true;
                    isColliding = false;
                }
            }
        }
    }

    IEnumerator setIsKinematic()
    {
        scr_myLittleMan.allowFallingFalse();
        yield return new WaitForSeconds(0.75f);
        scr_myLittleMan.setIsKinematicFalse();
        hasStoppedColliding = false;
        scr_myLittleMan.allowFallingTrue();

    }

}