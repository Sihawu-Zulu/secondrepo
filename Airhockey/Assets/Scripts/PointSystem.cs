using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class numberpoints : MonoBehaviour
{
    public TextMeshPro PLayerScoretext;

    public TextMeshPro AIScoretext;

    private int Playerscore;

    private int AIscore;

    public Transform Winner;

    public GameObject Loser;

    public Transform center;

    public GameObject RestartButton;

    public GameObject WinScreen;

    public GameObject PlayAgainButton;



    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();

        WinScreen.SetActive(false);

        RestartButton.SetActive(false);

        PlayAgainButton.SetActive(false);                   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Playerscore >= 5 || AIscore >= 5)
        {
            return; // Exit the method early if the game has already ended


            RestartButton.SetActive(true);
        }


        if (collision.gameObject.CompareTag("Goal"))
        {
            Playerscore++;
        }
        else if (Playerscore == 5)
        {
            Instantiate(Winner, center.position, Quaternion.identity);

            RestartButton.SetActive(true);

            WinScreen.SetActive(true);

            PlayAgainButton.SetActive(true);   

        }

        if (collision.gameObject.CompareTag("Goal2"))
        {
            AIscore++;
        }
        else if (AIscore == 5)
        {
            Instantiate(Winner, center.position, Quaternion.identity);

            RestartButton.SetActive(true);

            PlayAgainButton .SetActive(true);

        }


        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        // Update the text of the TextMeshPro components
        PLayerScoretext.text = "" + Playerscore;

        AIScoretext.text = "" + AIscore;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player or AI has won

    }
}