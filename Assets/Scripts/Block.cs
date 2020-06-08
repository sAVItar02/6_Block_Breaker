using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Block : MonoBehaviour
{
    Level level;
    GameStatus gameStatus;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayPopSound();
        level.ReduceBreakableBlocks();
        gameStatus.AddScore();
        Destroy(gameObject);
    }

    private static void PlayPopSound()
    {
        GameObject ball = GameObject.Find("Ball");
        Ball sound = ball.GetComponent<Ball>();
        sound.GetComponent<AudioSource>().PlayOneShot(sound.popSound);
    }
}
