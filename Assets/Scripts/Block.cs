using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Block : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject ball = GameObject.Find("Ball");
        Ball sound = ball.GetComponent<Ball>();
        sound.GetComponent<AudioSource>().Play();
        Destroy(gameObject);
    }
}
