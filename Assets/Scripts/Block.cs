using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Block : MonoBehaviour
{
    Level level;
    GameSession gameStatus;

    [SerializeField] ParticleSystem impactParticles;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameSession>();
        if(tag == "Breakable")
        {
            CountBreakableBlocks();
        }
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        level.CountBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            PlayPopSound();
            InitiateDestroySequnce();
        }
    }

    private void InitiateDestroySequnce()
    {
        level.ReduceBreakableBlocks();
        gameStatus.AddScore();
        PlayParticleEffects();
        Destroy(gameObject);
    }

    private static void PlayPopSound()
    {
        GameObject ball = GameObject.Find("Ball");
        Ball sound = ball.GetComponent<Ball>();
        sound.GetComponent<AudioSource>().PlayOneShot(sound.popSound);
    }

    private void PlayParticleEffects()
    {
        var effect = Instantiate(impactParticles, gameObject.transform.position, Quaternion.identity);
        Destroy(effect, 1f);
    }
}
