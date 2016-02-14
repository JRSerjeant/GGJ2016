using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UISetScores : MonoBehaviour {
    public Text blueBlock;
    public Text blueBall;
    public Text redBlock;
    public Text redBall;
    public Text score;

    public blockController blockController;

    // Use this for initialization
    void Start () {
        blueBall.text = "Balls \n 00";
        blueBlock.text = "Blocks \n 00";
        redBall.text = "Balls \n 00";
        redBlock.text = "Blocks \n 00";
        score.text = "";

    }
	
	// Update is called once per frame
	void Update () {
        blueBall.text = "Ball \n" + createBall.numberofBalls;
        blueBlock.text = "Blocks\n" + (blockController.getBlockCount - blockController.getBluePlayerBlockCount);
        redBall.text = "Balls \n" + createBall.numberofBalls;
        redBlock.text = "Blocks\n "+ ( blockController.getBlockCount - blockController.getRedPlayerBlockCount);
        score.text = "Blue: " + scoreController.BluePlayerScore + "\nRed: " + scoreController.RedPlayerScore;
    }
}
