using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    private int playerScore;

    private int aiScore;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goal2"))
        {

            aiScore++;

            if (playerScore >= 5)
            {
                SceneManager.LoadSceneAsync("Play Again");
            }
        }


        if (collision.gameObject.CompareTag("goal"))
        {
            playerScore++;


            if (aiScore >= 5)
            {
                SceneManager.LoadSceneAsync("Play Again");
            }
        }
    }
}