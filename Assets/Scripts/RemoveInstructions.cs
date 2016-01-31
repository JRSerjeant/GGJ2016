using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RemoveInstructions : MonoBehaviour {
    public Text Instructions;
    public Text InstructionsBlue;
    public Text InstructionsRed;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.timeSinceLevelLoad > 10)
        {
            Instructions.enabled = false;
            InstructionsBlue.enabled = false;
            InstructionsRed.enabled = false;
        }
	
	}
}
