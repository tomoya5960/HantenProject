using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallFade : MonoBehaviour
{
    void Start()
    {
        GameFade.instance.FadeIn(1);
    }
}
