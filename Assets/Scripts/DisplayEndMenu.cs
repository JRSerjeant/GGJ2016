using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayEndMenu : MonoBehaviour {
    public GameObject restartButton;
    public GameObject exitButton;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(TimeControllerScript.IsGameOver)
        {
            restartButton.SetActive(true);
            exitButton.SetActive(true);
        }
	
	}
}
