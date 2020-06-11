using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    Health health;
    Ball ball;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
        health = FindObjectOfType<Health>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ball"))
        {
            if (health.currentHealth <= 1)
            {
                StartDeathSequence();
            }
            else
            {
                ball.GetComponent<AudioSource>().PlayOneShot(ball.dieSound);
                ball.hasStarted = false;
                health.ReduceHealth();
                ball.LockBallToPaddle();
                ball.LaunchOnMouseClick();
            }
        }
    }

    private void StartDeathSequence()
    {
        Debug.Log("Death");
        SceneManager.LoadScene("Game Over");
    }
}
