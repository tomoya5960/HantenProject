using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private bool _isHaveRope = false;    //���[�v�������Ă��邩
    [SerializeField]
    private      Vector2 _isPlayerPos = Vector2.zero;
    [SerializeField]
    private int playerSpeed = 2;
    public  bool isPlayerMove = false;  //�v���C���[�������Ă��邩
    void Start()
    {

        //�}�b�v�c�[���Ő������ꂽ�v���C���[�𓮂��Ȃ��悤�ɂ���
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
                Debug.Log("�ړ��\����������Ƃ���ŕςȎw���o���Ă񂶂�˂���");
                break;

        }

    }

    public void PlayerMove(int direction)
    {
        switch (direction)
        {
            case 0: //��

                break;
            case 1: //��

                break;
            case 2: //��

                break;
            case 3: //�E

                break;
            default:
                Debug.Log("�ړ��ŕςȎw���o���Ă񂶂�˂���");
                break;

        }
        
    }
}
