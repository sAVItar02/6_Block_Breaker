using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Block : MonoBehaviour
{
    //Config Params
    [SerializeField] ParticleSystem impactParticles;
    [SerializeField] Sprite[] damageLevels;
    [SerializeField]PowerUp powerUp;
    public bool hasPowerUp = false;

    //cache reaference
    Level level;

    //state variables
    [SerializeField] int timesHit = 0;


    private void Start()
    {
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
            HandleHits();
            if(hasPowerUp == true)
            {
                InstantiateRandomPowerUp();
            }
        }
    }

    private void InstantiateRandomPowerUp()
    {
        Instantiate(powerUp, transform.position, Quaternion.identity);
    }

    private void HandleHits()
    {
        timesHit++;
        int maxHits = damageLevels.Length + 1;
        if(timesHit < maxHits)
        {
            PlayCrackSound();
            showDamagedSprite();
        }
        else if (timesHit >= maxHits)
        {
            PlayPopSound();
            InitiateDestroySequence();
        }
    }

    private void showDamagedSprite()
    {
        int nextSprite = timesHit - 1; 
        if(damageLevels[nextSprite] != null)
        {
            GetComponent<SpriteRenderer>().sprite = damageLevels[nextSprite];
        }
        else
        {
            Debug.LogError("Sprites on Block " + gameObject.name + " missing");
        }
    }

    private void InitiateDestroySequence()
    {
        level.ReduceBreakableBlocks();
        FindObjectOfType<GameSession>().AddScore();
        //PlayParticleEffects();
        Destroy(gameObject);
    }

    private static void PlayPopSound()
    {
        GameObject ball = GameObject.Find("Ball");
        Ball sound = ball.GetComponent<Ball>();
        sound.GetComponent<AudioSource>().PlayOneShot(sound.popSound);
    }

    private void PlayCrackSound()
    {
        GameObject ball = GameObject.Find("Ball");
        Ball sound = ball.GetComponent<Ball>();
        sound.GetComponent<AudioSource>().PlayOneShot(sound.crackSound);
    }

    private void PlayParticleEffects()
    {
        var effect = Instantiate(impactParticles, gameObject.transform.position, Quaternion.identity);
        Destroy(effect, 1f);
    }
}
