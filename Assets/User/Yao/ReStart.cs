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
        if (GeneralManager.Instance.isPlay && !StageManager.Instance.isPlayerMove)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
