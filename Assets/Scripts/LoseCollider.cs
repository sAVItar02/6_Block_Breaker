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
        if(health.currentHealth <= 1)
        {
            StartDeathSequence();
        }
        else
        {
            health.ReduceHealth();
            ball.LockBallToPaddle();
        }
    }

    private void StartDeathSequence()
    {
        Debug.Log("Death");
        SceneManager.LoadScene("Game Over");
    }
}
