using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle : MonoBehaviour
{
    [SerializeField]
    private JsonData jsonData;

    public void OnTggleChanged()
    {
        if(jsonData.overWriteSave)
            jsonData.overWriteSave=false;
        else
            jsonData.overWriteSave=true;
    }
}
