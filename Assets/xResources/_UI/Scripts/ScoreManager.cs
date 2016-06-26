using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public int RedScore;
    public int BlueScore;
    Text score;


	// Use this for initialization
	void Start ()
    {
        score = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        score.text = BlueScore + " : " + RedScore;
	}
}
