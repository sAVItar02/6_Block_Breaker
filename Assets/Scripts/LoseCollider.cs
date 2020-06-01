using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    //[SerializeField] float levelLoadDelay = 2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartDeathSequence();
    }

    private static void StartDeathSequence()
    {
        Debug.Log("Death");
        SceneManager.LoadScene("Game Over");
    }
}
