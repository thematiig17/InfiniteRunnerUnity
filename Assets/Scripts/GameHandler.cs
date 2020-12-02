using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public GameObject RestartMenuPanel;
    public static bool gameOver;
    public GameObject[] HealPoints;
    public GameObject Player;
    public static bool trapHitted;
    public static bool healthGained;
    private int healthPoints = 3;
    // Start is called before the first frame update
    void Start()
    {
        RestartMenuPanel.gameObject.SetActive(false);
        gameOver = false;
        trapHitted = false;
        healthGained = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            RestartMenuPanel.gameObject.SetActive(true);
        }
        if (trapHitted)
        {
            TrapTriggered();
            trapHitted = false;
        }
        if (healthGained)
        {
            HealthGained();
        }
    }

    public void RestartButtonClick()
    {
        SceneManager.LoadScene("SampleScene");
        
    }

    public void TrapTriggered()
    {
        healthPoints--;
        if (healthPoints == 3)
        {
            for (int i = 0; i < 3; i++)
            {
                HealPoints[i].SetActive(true);
            }
        }
        if (healthPoints == 2)
        {
            HealPoints[2].SetActive(false);
            HealPoints[1].SetActive(true);
            HealPoints[0].SetActive(true);
        }
        if (healthPoints == 1)
        {
            HealPoints[1].SetActive(false);
            HealPoints[0].SetActive(true);
        }
        if (healthPoints == 0)
        {
            HealPoints[0].SetActive(false);
            gameOver = true;
            Player.SetActive(false);
        }
    }
    public void HealthGained()
    {
        if (healthPoints <= 3)
        {
            healthPoints++;
            healthGained = false;
        }
        else
        {
            PlayerMovement.numberOfPoints++;
            healthGained = false;
        }
    }
}
