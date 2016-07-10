using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public int RedScore;
    public int BlueScore;
    Text score;
    public bool gameover;
    public AudioSource audio;



	// Use this for initialization
	void Start ()
    {
        gameover = false;
        score = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!gameover)
        {
            score.text = BlueScore + " : " + RedScore;
            if(BlueScore == 30 || RedScore == 30)
            {
                gameover = true;
                score.text = BlueScore + " : " + RedScore + "\n" + "Game Over" + "\n" + "Space to Restart";
            }
        }
	}
}
