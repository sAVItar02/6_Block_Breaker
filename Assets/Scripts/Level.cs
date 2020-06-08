﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks = 0;

    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void ReduceBreakableBlocks()
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
