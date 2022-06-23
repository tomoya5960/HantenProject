using UnityEngine;
[RequireComponent(typeof(SE))]
[RequireComponent(typeof(BGM))]
public class SoundManagers : MonoBehaviour
{
    [HideInInspector]
    public BGM bgm;  //BGM�}�l�[�W���[�i�[
    [HideInInspector]
    public SE se;   //SE�}�l�[�W���[�i�[

    private void Awake()
    {
        bgm = GetComponent<BGM>();
        se = GetComponent<SE>();
    }
}
