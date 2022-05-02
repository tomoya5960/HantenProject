using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [HideInInspector]
    public BGM bgm;  //BGMマネージャー格納
    [HideInInspector]
    public SE se;   //SEマネージャー格納

    private void Awake()
    {
        bgm = GetComponent<BGM>();
        se = GetComponent<SE>();
    }
}
