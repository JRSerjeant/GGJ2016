using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class scr_ground : MonoBehaviour {

    TextMesh tm;
    GameObject textHP;

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
        
    }
	
	// Update is called once per frame
	void Update () {

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
    }
}
