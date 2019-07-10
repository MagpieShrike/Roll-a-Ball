using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text scoreText; 
    public Text winText;
    public Text livesText;

    private Rigidbody rb;
    private int count;
    private int score;
    private int lives;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;
        SetCountText();

        score = 0;
        SetScoreText();

        lives = 3;
        setLivesText();

        winText.text = "";

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();

        LevelUpdate();
    }

    // Destroy everything that enters the trigger
    void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            score = score + 1;
            SetScoreText();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            score = score - 1;
            SetScoreText();
            lives = lives - 1;
            setLivesText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score == 28)
        {
            winText.text = "You Win!";
        }
    }

    void setLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();

        if (lives == 0)
        {
            winText.text = "You Lose";
            GameObject.FindWithTag("Player").SetActive(false);
        }
    }

    void LevelUpdate()
    {
        if (score == 12)
        {
            GameObject.FindWithTag("Exit").SetActive(false);
        }
        else if (score == 11 && count == 13)
        {
            GameObject.FindWithTag("Exit").SetActive(false);
        }
        else if (score == 10 && count == 14)
        {
            GameObject.FindWithTag("Exit").SetActive(false);
        }
        else if (score == 9 && count == 15)
        {
            GameObject.FindWithTag("Exit").SetActive(false);
        }
        else if (score == 8 && count == 16)
        {
            GameObject.FindWithTag("Exit").SetActive(false);
        }
    } 
}
