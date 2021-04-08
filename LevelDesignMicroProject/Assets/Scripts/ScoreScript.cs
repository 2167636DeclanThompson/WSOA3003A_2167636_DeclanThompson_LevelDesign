using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text playerScoreDisplay;

    private int playerScore;
    public void PlayerScored(int playerID)
    {
        if (playerID == 1)
        {
            playerScore++;
        }
        UpdateScore();
        {


        }
    }

    private void UpdateScore()
    {
        playerScoreDisplay.text = playerScore.ToString();

    }
}
