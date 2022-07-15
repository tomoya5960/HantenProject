using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    public void OnReStart()
    {
        if (GeneralManager.instance.isEnablePlay)
        {
            if (!GeneralManager.instance.mapManager.player.isPlayerMove)
                SceneManager.LoadScene("GameScene");
        }
    }
}
