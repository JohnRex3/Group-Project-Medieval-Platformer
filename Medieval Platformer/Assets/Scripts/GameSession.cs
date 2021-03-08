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

    [SerializeField] float timer = 360f;

    public Player Die;

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
        scoreText.text = scoreText.ToString();
        timerText.text = timer.ToString();
    }
    public void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString();
        if (timer <= 0)
        {
            Die.GetComponent<Player>().Die();
        }
    }

    public void AddToScore(int pointsToAdd)
    {
        playerScore += pointsToAdd;
        scoreText.text = playerScore.ToString();

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

    private void TakeLife()
    {
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
