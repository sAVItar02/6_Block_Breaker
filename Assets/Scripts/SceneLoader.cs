﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    /*public Animator transition;
    [SerializeField] float transitionTime = 1f;*/
    [SerializeField] SceneFader fader;
    

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        fader.FadeTo(currentSceneIndex + 1);
    }

    /*IEnumerator LoadScene(int levelIndex)
    {
        transition.SetTrigger("Start-Anim");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
*/
    public void LoadStartScene()
    {
        fader.FadeTo(0);
        FindObjectOfType<GameSession>().ResetGameSession();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
