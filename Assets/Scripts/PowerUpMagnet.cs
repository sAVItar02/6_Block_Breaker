using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMagnet : MonoBehaviour
{
    Ball ball;
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -2.5f);       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            ball.hasStarted = false;
            ball.LockBallToPaddle();
            ball.LaunchOnMouseClick();
        }
    }
}
