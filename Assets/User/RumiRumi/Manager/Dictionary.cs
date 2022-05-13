using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dictionary : MonoBehaviour
{
    public Dictionary<int, string> dictionary = new Dictionary<int, string>()   //タイルIDとタイル名の辞書
    {
        {0, "invisible"},
        {1, "aisle_01"},
        {2, "aisle_02"},
        {3, "aisle_03"},
        {4, "wall_01"},
        {5, "wall_02"},
        {6, "wall_03"},
        {7, "goal_01"},
        {8, "goal_02"},
        {9, "goal_03"},
        {10, "wall_99"},
        {11, "stone"},
        {12, "statue_01"},
        {13, "statue_02"},
        {14, "statue_03"},
        {15, "statue_04"},
        {16, "statue_11"},
        {17, "statue_12"},
        {18, "statue_13"},
        {19, "statue_14"},
    };
    /// <summary> 画像の名前を検索する関数 </summary>
    public string ImageName(int key)
    {
        if (dictionary.ContainsKey(key))
        {
            return dictionary[key]; //該当する画像名を返す
        }
        else
        {
            Debug.LogError("該当する画像が見つからなかったよ！ Key =[" + key + "]");
            return dictionary[0];  //無かったら透明を返す
        }
    }
}
