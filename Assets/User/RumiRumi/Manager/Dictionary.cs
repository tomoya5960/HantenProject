using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dictionary : MonoBehaviour
{
    public Dictionary<int, string> dictionary = new Dictionary<int, string>();

    private void Awake()
    {
        dictionary.Clear();
        dictionary.Add(0, "invisible");
        dictionary.Add(1, "aisle_01");
        dictionary.Add(2, "aisle_02");
        dictionary.Add(3, "aisle_03");
        dictionary.Add(4, "wall_01");
        dictionary.Add(5, "wall_02");
        dictionary.Add(6, "wall_03");
        dictionary.Add(7, "goal_01");
        dictionary.Add(8, "goal_02");
        dictionary.Add(9, "goal_03");
        dictionary.Add(10, "wall_99");
        dictionary.Add(11, "stone");
        dictionary.Add(12, "statue_01");
        dictionary.Add(13, "statue_02");
        dictionary.Add(14, "statue_03");
        dictionary.Add(15, "statue_04");
        dictionary.Add(16, "statue_11");
        dictionary.Add(17, "statue_12");
        dictionary.Add(18, "statue_13");
        dictionary.Add(19, "statue_14");
    }

    /// <summary> ‰æ‘œ‚Ì–¼‘O‚ğŒŸõ‚·‚éŠÖ” </summary>
    public string ImageName(int key)
    {
        if (dictionary.ContainsKey(key))
        {
            return dictionary[key]; //ŠY“–‚·‚é‰æ‘œ–¼‚ğ•Ô‚·
        }
        else
        {
            Debug.LogError("ŠY“–‚·‚é‰æ‘œ‚ªŒ©‚Â‚©‚ç‚È‚©‚Á‚½‚æI");
            return dictionary[0];  //–³‚©‚Á‚½‚ç“§–¾‚ğ•Ô‚·
        }
    }
}
