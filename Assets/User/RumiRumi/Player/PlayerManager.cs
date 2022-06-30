using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private Canvas canvas;
    [HideInInspector]
    public bool isHaveRope = false;    //���[�v�������Ă��邩
    [HideInInspector]
    public Vector2 isPlayerPos = Vector2.zero;
    public float playerSpeed = 2;
    public bool isPlayerMove = false;  //�v���C���[�������Ă��邩

    private void Awake()
    {
        canvas = GameObject.Find("Canvas").gameObject.GetComponent<Canvas>();
    }
    void Start()
    {

        //�}�b�v�c�[���Ő������ꂽ�v���C���[�𓮂��Ȃ��悤�ɂ���
        if (SceneManager.GetActiveScene().name == "MapEditorScene")
        {
            //�}�b�v�c�[���œǂݍ��݂��s�����ۂ�BeforePlayer�ɓǂݍ��܂ꂽ�}�b�v�ɂ���Player���i�[����B��������邱�Ƃœǂݍ��݂��s�����ۂ�Player���d�����邱�Ƃ�h��
            GameObject.Find("MapTool").gameObject.GetComponent<Mouse>().beforePlayer = gameObject.transform.parent.gameObject;
            gameObject.GetComponent<Player>().enabled = false;
            gameObject.GetComponent<PlayerManager>().enabled = false;
        }
        else
        {
            GeneralManager.instance.mapManager.PlayerPos = gameObject.transform.parent.GetComponent<TileData>().tilePos;
            isPlayerPos = GeneralManager.instance.mapManager.PlayerPos;    //�v���C���[�̃X�^�[�g�ʒu���i�[
        }
    }

    /// <summary>
    /// Player�̍��W���̏�������
    /// </summary>
    /// <param name="direction"></param>
    public void SetPlayerPos(int direction)
    {
        switch (direction)
        {
            case 0:
                if (GeneralManager.instance.mapManager.Move(0))
                {
                    GeneralManager.instance.mapManager.PlayerPos += new Vector2(-1, 0);
                    isPlayerPos += new Vector2(-1, 0);
                    gameObject.transform.Translate(0, 130, 0);
                }
                else
                    CheckGoal(0);
                break;
            case 1:
                if (GeneralManager.instance.mapManager.Move(1))
                {
                    GeneralManager.instance.mapManager.PlayerPos += new Vector2(1, 0);
                    isPlayerPos += new Vector2(1, 0);
                    gameObject.transform.Translate(0, -130, 0);
                }
                else
                    CheckGoal(1);
                break;
            case 2:
                if (GeneralManager.instance.mapManager.Move(2))
                {
                    GeneralManager.instance.mapManager.PlayerPos += new Vector2(0, -1);
                    isPlayerPos += new Vector2(0, -1);
                    gameObject.transform.Translate(-130, 0, 0);
                }
                else
                    CheckGoal(2);
                break;
            case 3:
                if (GeneralManager.instance.mapManager.Move(3))
                {
                    GeneralManager.instance.mapManager.PlayerPos += new Vector2(0, 1);
                    isPlayerPos += new Vector2(0, 1);
                    gameObject.transform.Translate(130, 0, 0);
                }
                else
                    CheckGoal(3);
                break;
            default:
                Debug.Log("�ړ��\����������Ƃ���ŕςȎw���o���Ă񂶂�˂���");
                break;
        }
        GeneralManager.instance.mapManager.IsCheckClear();
    }

    /// <summary>
    /// �ړ��悪�S�[���ŁA���[�v�������Ă�����S�[���ł���悤�ɂ���
    /// </summary>
    /// <param name="direction"></param>
    public void CheckGoal(int direction)
    {
        GameObject obj;
        switch (direction)
        {
            case 0:
                obj = GeneralManager.instance.mapManager.mapPosX[(int)isPlayerPos.x - 1].mapPosY[(int)isPlayerPos.y].gameObject;
                break;
            case 1:
                obj = GeneralManager.instance.mapManager.mapPosX[(int)isPlayerPos.x + 1].mapPosY[(int)isPlayerPos.y].gameObject;
                break;
            case 2:
                obj = GeneralManager.instance.mapManager.mapPosX[(int)isPlayerPos.x].mapPosY[(int)isPlayerPos.y - 1].gameObject;
                break;
            case 3:
                obj = GeneralManager.instance.mapManager.mapPosX[(int)isPlayerPos.x].mapPosY[(int)isPlayerPos.y + 1].gameObject;
                break;
            default:
                Debug.Log("�ړ��\����������Ƃ���ŕςȎw���o���Ă񂶂�˂���");
                return;
        }
        //�S�[����������
        if (obj.GetComponent<TileData>().imageID == (int)MapType.ImageIdType.goal_01 && isHaveRope)
        {
            obj.GetComponent<TileMaster>().TurnImage(isHaveRope);
            isHaveRope = false;
        }
    }
}