﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpLengthIncrese : MonoBehaviour
{
    [SerializeField] float increaseFactor = 0.3f;
    Paddle paddle;
    void Start()
    {
        paddle = FindObjectOfType<Paddle>();
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickupLengthIncrease(collision);
            Destroy(gameObject);
        }
    }

    private void PickupLengthIncrease(Collider2D player)
    {
        paddle.GetComponent<AudioSource>().PlayOneShot(paddle.collectSFX);
        Vector3 lTemp = player.transform.localScale;
        lTemp.x += increaseFactor;
        player.transform.localScale = lTemp;
        paddle.minX += increaseFactor;
        paddle.maxX -= increaseFactor;
    }
}
