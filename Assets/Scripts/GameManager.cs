using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int score = 1;
    [SerializeField] private Text scoreText;

    public bool gameOver=false;
    public bool gameFinish=false;

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        if (GameObject.Find("Shuriken") == null)
        {
            gameOver= true;
            gameFinish= false;
        }

        if (gameFinish == true && gameOver==false)
        { 
        winPanel.SetActive(true);
        losePanel.SetActive(false);
        }
        if(gameFinish==false && gameOver == true)
        {
            losePanel.SetActive(true);
            winPanel.SetActive(false);
        }
    }


    public void RestartLevel() 
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }


    public void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;   
        int sceneIndex = SceneManager.sceneCountInBuildSettings - 1;      

        if (nextSceneIndex <= sceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }

        if (nextSceneIndex > sceneIndex)
        {
            SceneManager.LoadScene(0);
        }


    }
}
