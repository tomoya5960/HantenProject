using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapType : MonoBehaviour
{
    public enum ImageIdType
    {
        invisible = 0,
        aisle_01,
        aisle_02,
        aisle_03,
        wall_01,
        wall_02,
        wall_03,
        goal_01,
        goal_02,
        goal_03,
        wall_99,
        stone,
        statue_01,
        statue_02,
        statue_03,
        statue_04,
        statue_11,
        statue_12,
        statue_13,
        statue_14,
    }

    [HideInInspector]
    public ImageIdType imageName;
    //[HideInInspector]
    public List<string> jsonList = new List<string>(); //JsonDataƒŠƒXƒg

    private void Awake()
    {
        var JsonData = Resources.LoadAll<TextAsset>("MapData");
        foreach (var json in JsonData)
        {
            jsonList.Add(json.text);
        }
    }
}