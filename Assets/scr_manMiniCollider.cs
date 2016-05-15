using UnityEngine;
using Assets.Scripts;
using System.Collections;

public class scr_manMiniCollider : MonoBehaviour
{
    GameObject obj_lastCollidedGround;
    GameObject obj_myLittleMan;
    scr_littleMan scr_myLittleMan;
    BoxCollider2D collider;
    BoxCollider2D obj_lastCollidedGroundBoxCollider2D;

    // Use this for initialization
    void Start()
    {
        collider = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (obj_lastCollidedGround != null)
        {
            obj_lastCollidedGroundBoxCollider2D = obj_lastCollidedGround.GetComponent<BoxCollider2D>();
            if ((this.transform.position.y - (collider.size.y / 2)) > (obj_lastCollidedGround.transform.position.y + (obj_lastCollidedGroundBoxCollider2D.size.y /2)))
            {
                Debug.Log((this.transform.position.y - (collider.size.y / 2)));
                Debug.Log((obj_lastCollidedGround.transform.position.y + (obj_lastCollidedGroundBoxCollider2D.size.y / 2)));
                collider.enabled = false;
                scr_myLittleMan.currentState = scr_littleMan.manState.Running;
                if (this.transform.position.x > obj_lastCollidedGround.transform.position.x)
                {
                    obj_lastCollidedGround = null;
                    collider.enabled = true;
                    
                }
            }
        }
    }

    public void Initialize(GameObject MyLittleMan)
    {
        obj_myLittleMan = MyLittleMan;
        scr_myLittleMan = obj_myLittleMan.GetComponent<scr_littleMan>();
    }

    void OnTriggerEnter2D(Collider2D otherObject)
    {
        Debug.Log("Col with: " + otherObject.gameObject.name);
        
        if (otherObject.gameObject.tag == "ground")
        {
            obj_lastCollidedGround = otherObject.gameObject;
            scr_myLittleMan.currentState = scr_littleMan.manState.Climbing;
        }
    }
    void OnTriggerExit2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.tag == "ground")
        {
            scr_myLittleMan.currentState = scr_littleMan.manState.Running;
        }
    }
}