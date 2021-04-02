using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int playerScore = 0;

    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;
    [SerializeField] Text timerText;

    [SerializeField] float timer = 300f;

    float timerCountDown = 0;

    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = scoreText.ToString() + "/how ever many coins we have";
        timerText.text = timerCountDown.ToString();
        timerCountDown = timer;
    }
    public void Update()
    {
        timerCountDown -= Time.deltaTime;
        timerText.text = timerCountDown.ToString();
        if (timerCountDown <= 0)
        {
         TakeLife();
         timerCountDown = timer;
        }
    }

    public void AddToScore(int pointsToAdd)
    {
        playerScore += pointsToAdd;
        scoreText.text = playerScore.ToString();

    }

    public void AddToLifeTotal()
    {
        playerLives += 1;
        livesText.text = playerLives.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    public void TakeLife()
    {
        //Play Death Animation Here
        playerLives--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(0); // make sure main menu is set to be scene 0 // 
        Destroy(gameObject);
    }
}
