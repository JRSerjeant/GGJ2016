using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class scr_ground : MonoBehaviour {

    TextMesh tm;

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
        GameObject textHP = Instantiate(objectFactory.pfb_DisplayTextNumber, this.transform.position, new Quaternion()) as GameObject;
        tm = textHP.GetComponent<TextMesh>();
    }
	
	// Update is called once per frame
	void Update () {
        
        tm.text = groundHP.ToString();
    }
    public void removeHP()
    {
        Destroy(this.gameObject);
    }

    void disable()
    {
        tm.text = "0";
        Destroy(this.gameObject);
    }
}
