using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetStatus : MonoBehaviour
{
    [SerializeField] Text livesCount;
    [SerializeField] Text scoresCount;
    // Start is called before the first frame update
    void Start()
    {
        livesCount.text = FindObjectOfType<GameSession>().Lives().ToString();
        scoresCount.text = FindObjectOfType<GameSession>().Scores().ToString();
        FindObjectOfType<GameSession>().DestroyHUD();
    }

}
