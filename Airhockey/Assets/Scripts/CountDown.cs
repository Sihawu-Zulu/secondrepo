using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    public float speed = 1f;

    public TextMeshPro timer;

    public bool spacepressed = false;

    public Transform center;

    public GameObject puck;

    

    public GameObject StartScreen;

   

    // Start is called before the first frame update
    void Start()
    {
        StartScreen.SetActive (true);
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space) && !spacepressed)
        {
            spacepressed = true;

            StartScreen.SetActive (false);

            StartCoroutine(Countdown());
            
        }
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

        GameStart();

        yield return new WaitForSeconds(4);

        timer.text = "";
    }

   void GameStart()
    {
        Rigidbody2D rb = puck.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = Random.insideUnitCircle * speed;
        }
    }


    // Update is called once per frame

}
