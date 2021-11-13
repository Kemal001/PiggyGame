using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject victoryPanel;
    public GameObject gameOverPanel;

    public int numberOfEnemies;
    [HideInInspector] public int currentNumOfEnemies;

    private GameObject player;

    private void Awake()
    {
        currentNumOfEnemies = numberOfEnemies;
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(currentNumOfEnemies <= 0)
        {
            victoryPanel.SetActive(true);
        }
        else
        {
            victoryPanel.SetActive(false);
        }

        if(!player.activeSelf)
        {
            gameOverPanel.SetActive(true);
        }
        else
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level");
    }
}
