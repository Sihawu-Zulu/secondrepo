using System.Collections;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ballmovement : MonoBehaviour
{
   

    public TextMeshPro AIScoreText;

    public TextMeshPro PlayerScoreText;

    public float speed = 5f; 

    public Transform center;

    public float collisionForce = 10f;

    private Rigidbody2D rb;

    private int aiScore;

    private int playerScore;

    private bool spacePressed = false;

    private CountDown countdownScript;

    public GameObject winner;

    public GameObject lose;

    public TextMeshPro timer;

    public GameObject player;

    public GameObject Puck;

    public GameObject AIplayer;

    public GameObject texts;

    public GameObject button;


    void Start()
    {
        countdownScript = GetComponent<CountDown>();

        UpdateScoreText();

        winner.SetActive(false);

        lose.SetActive(false);

        button.SetActive(false);

       
    }

    public IEnumerator Countdown()
    {
        timer.text = "3";
        yield return new WaitForSeconds(1);

        timer.text = "2";
        yield return new WaitForSeconds(1);

        timer.text = "1";
        yield return new WaitForSeconds(1);

        timer.text = "Play";

        MoveBall();

        yield return new WaitForSeconds(4);

        timer.text = "";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        
           
        




        if (collision.gameObject.CompareTag("goal") || collision.gameObject.CompareTag("Goal2"))
        {
            transform.position = center.position;
            rb.velocity = Vector3.zero;
            StartCoroutine(Countdown());

            if (collision.gameObject.CompareTag("goal"))
                playerScore++;
            else if (collision.gameObject.CompareTag("Goal2"))
                aiScore++;

            UpdateScoreText();
        }
    }

    void Update()
    {
        if (playerScore >= 5)
        {
            Debug.Log("You win");
            winner.SetActive(true);
            texts.SetActive(false);

            player.SetActive(false);

            Puck.SetActive(false);

            AIplayer.SetActive(false);
            timer.SetAllDirty();
            button.SetActive(true);
            // Implement win logic here
        }

        void Sceneloader(string sceneName)
        {
            if (playerScore >= 5)
            {
                SceneManager.LoadScene("Play Again");
            }
        }
  
     


        if (aiScore >= 5)
        {
            Debug.Log("You lose");
            lose.SetActive(true);
            texts.SetActive(false);

            player.SetActive(false);

            Puck.SetActive(false);

            AIplayer.SetActive(false);
            AIplayer.SetActive(false);

            button.SetActive(true);
            // Implement lose logic here
        }

        // If the ball's velocity is too low, increase it to maintain minimum speed
        if (Input.GetKeyUp(KeyCode.Space) && !spacePressed)
        {
            spacePressed = true;
            StartCoroutine(Countdown());
        }
    }

    private void UpdateScoreText()
    {
        PlayerScoreText.text = playerScore.ToString();
        AIScoreText.text = aiScore.ToString();
    }

    void MoveBall()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb.velocity.magnitude < speed)
        {
            rb.velocity = Random.insideUnitCircle.normalized * speed;
        }
    }

    void CheckScore()
    {
        
    }

    public void StopMovement()
    {
        rb.velocity = Vector2.zero;
    }
}

