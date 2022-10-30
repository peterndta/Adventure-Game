using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int scores = 0;

    [SerializeField] Text livesText;
    [SerializeField] Text scoresText;

    private void Awake()
    {
        int numGameSesion = FindObjectsOfType<GameSession>().Length;
        if(numGameSesion > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = playerLives.ToString();
        scoresText.text = scores.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if(playerLives > 1)
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
        Time.timeScale = 1f;
    }    
    
    public void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        Destroy(gameObject);
    }

    public void AddScores(int score)
    {
        scores += score;
        scoresText.text = scores.ToString();
    }

    public int Scores()
    {
        return scores;
    }    
    
    public int Lives()
    {
        return playerLives;
    }    
    
    public void DestroyHUD()
    {
        livesText.text = "";
        scoresText.text = "";
    }
}
