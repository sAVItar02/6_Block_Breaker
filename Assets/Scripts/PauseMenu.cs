using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    Ball ball;

    Vector2 tempVelocity;
    void Start()
    {
        ball = FindObjectOfType<Ball>();   
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gameIsPaused = false;
        ball.myRigidBody.velocity = tempVelocity;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        gameIsPaused = true;
        tempVelocity = ball.myRigidBody.velocity;
        ball.myRigidBody.velocity = new Vector2(0f, 0f);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        gameIsPaused = false;
        FindObjectOfType<GameSession>().ResetGameSession();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
