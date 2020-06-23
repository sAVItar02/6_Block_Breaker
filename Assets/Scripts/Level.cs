using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks = 0;
    Ball ball;
    SceneLoader sceneLoader;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void ReduceBreakableBlocks()
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
            ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            sceneLoader.LoadNextScene();
        }
    }
}
