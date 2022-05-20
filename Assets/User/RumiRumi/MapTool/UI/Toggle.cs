using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle : MonoBehaviour
{
    [SerializeField]
    private JsonData jsonData;
    [SerializeField]
    private Mouse mouse;

    public void OnTggleChanged()
    {
        if(jsonData.overWriteSave)
            jsonData.overWriteSave=false;
        else
            jsonData.overWriteSave=true;
    }
    public void OnRopeChanged()
    {
        if (mouse.isRope)
            mouse.isRope = false;
        else
            mouse.isRope = true;
    }
}
