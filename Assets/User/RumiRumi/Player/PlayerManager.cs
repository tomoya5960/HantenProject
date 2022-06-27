using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private bool _isHaveRope = false;    //ロープを持っているか
    [SerializeField]
    private      Vector2 _isPlayerPos = Vector2.zero;
    [SerializeField]
    private int playerSpeed = 2;
    public  bool isPlayerMove = false;  //プレイヤーが動いているか
    void Start()
    {

        //マップツールで生成されたプレイヤーを動かないようにする
        if (SceneManager.GetActiveScene().name == "MapEditorScene")
        {
            gameObject.GetComponent<Player>().enabled = false;
            gameObject.GetComponent<PlayerManager>().enabled = false;
        }
        else
        {
            GeneralManager.instance.mapManager.PlayerPos = transform.parent.gameObject.GetComponent<TileData>().tilePos;
            _isPlayerPos = GeneralManager.instance.mapManager.PlayerPos;
        }
    }

    public void SearchMove(int direction)
    {
        switch (direction)
        {
            case 0:
                if (GeneralManager.instance.mapManager.Move(0))
                {
                    GeneralManager.instance.mapManager.PlayerPos += new Vector2(-1, 0);
                    _isPlayerPos += new Vector2(-1, 0);
                    PlayerMove(0);
                }
                break;
            case 1:
                if (GeneralManager.instance.mapManager.Move(1))
                {
                    GeneralManager.instance.mapManager.PlayerPos += new Vector2(1, 0);
                    _isPlayerPos += new Vector2(1, 0);
                    PlayerMove(1);
                }
                break;
            case 2:
                if (GeneralManager.instance.mapManager.Move(2))
                {
                    GeneralManager.instance.mapManager.PlayerPos += new Vector2(0, -1);
                    _isPlayerPos += new Vector2(0, -1);
                    PlayerMove(2);
                }
                break;
            case 3:
                if (GeneralManager.instance.mapManager.Move(3))
                {
                    GeneralManager.instance.mapManager.PlayerPos += new Vector2(0, 1);
                    _isPlayerPos += new Vector2(0, 1);
                    PlayerMove(3);
                }
                break;
            default:
                Debug.Log("移動可能か検索するところで変な指示出してんじゃねえよ");
                break;

        }

    }

    public void PlayerMove(int direction)
    {
        switch (direction)
        {
            case 0: //上

                break;
            case 1: //下

                break;
            case 2: //左

                break;
            case 3: //右

                break;
            default:
                Debug.Log("移動で変な指示出してんじゃねえよ");
                break;

        }
        
    }
}
