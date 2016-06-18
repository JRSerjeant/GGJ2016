using UnityEngine;
using System.Collections;

public class scr_DisplayTextNumber_Text : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().sortingLayerID = 0;
        GetComponent<Renderer>().sortingLayerName = "Debug";
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
