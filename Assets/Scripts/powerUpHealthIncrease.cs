using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpHealthIncrease : MonoBehaviour
{
    Health health;
    Paddle paddle; 
    void Start()
    {
        health = FindObjectOfType<Health>();
        paddle = FindObjectOfType<Paddle>();
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            paddle.GetComponent<AudioSource>().PlayOneShot(paddle.collectSFX);
            health.IncreaseHealth();
            Destroy(gameObject);
        }
    }
}
