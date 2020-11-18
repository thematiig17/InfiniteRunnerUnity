using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public GameObject RestartMenuPanel;
    public static bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        RestartMenuPanel.gameObject.SetActive(false);
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            RestartMenuPanel.gameObject.SetActive(true);
        }
    }

    public void RestartButtonClick()
    {
        SceneManager.LoadScene("SampleScene");
        
    }
}
