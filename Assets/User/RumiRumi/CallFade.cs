using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallFade : MonoBehaviour
{
    private void Awake()
    {
        GeneralManager.instance.soundManager.StopBGM();
    }
    void Start()
    {
        GameFade.instance.FadeIn(1);
    }
}
