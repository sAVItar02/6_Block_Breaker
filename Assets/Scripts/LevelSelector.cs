using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public SceneFader fader;
    public void LoadLevel(int index)
    {
        fader.FadeTo(index);
    }
}
