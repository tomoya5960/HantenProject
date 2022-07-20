using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            OnReStart();
        }
    }
    public void OnReStart()
    {
        if (GeneralManager.instance.isEnablePlay)
        {
            if (!GeneralManager.instance.mapManager.player.isPlayerMove)
                SceneManager.LoadScene("GameScene");
        }
    }
}
