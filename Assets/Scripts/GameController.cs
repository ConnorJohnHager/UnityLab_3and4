using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject OneBallPrefab;
    public GameObject TwoBallPrefab;
    public GameObject ThreeBallPrefab;

    public int Score = 0;
    public int NumberOfBalls = 0;
    public int NextBall = 1;
    public int MaximumBalls = 15;
    public bool GameOver = true;

    public Text ScoreText;
    public Button PlayAgainButton;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AddABall", 1.5F, 1);
    }

    public void StartGame()
    {
        foreach (GameObject ball in GameObject.FindGameObjectsWithTag("GameController"))
        {
            Destroy(ball);
        }
        
        Score = 0;
        NumberOfBalls = 0;
        NextBall = 1;
        PlayAgainButton.gameObject.SetActive(false);
        GameOver = false;
        
    }

    void AddABall()
    {
        if (!GameOver)
        {
            if (NextBall == 3)
            {
                Instantiate(ThreeBallPrefab);
                NumberOfBalls++;
                NextBall = 1;
            }
            else if (NextBall == 2)
            {
                Instantiate(TwoBallPrefab);
                NumberOfBalls++;
                NextBall++;
            }
            else if (NextBall == 1)
            {
                Instantiate(OneBallPrefab);
                NumberOfBalls++;
                NextBall++;
            }

            if (NumberOfBalls >= MaximumBalls)
            {
                GameOver = true;
                PlayAgainButton.gameObject.SetActive(true);
            }
        }
    }

    public void ClickedOnBall()
    {
        Score++;
        NumberOfBalls--;
    }

    public void Update()
    {
        ScoreText.text = Score.ToString();
    }
}
