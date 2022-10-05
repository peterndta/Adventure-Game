using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadMainMenuLevel()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGameSession();
    }
}
