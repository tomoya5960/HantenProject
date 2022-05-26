using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStage : MonoBehaviour
{
    public GameObject bgPrefab;
    public GameObject blockPrefab;
    public GameObject charactorPrefab;
    public GameObject ItemPrefab;

    void Start()
    {
        int[][] tileMap = //�񎟌��z��ɂ��}�b�v���
        {
            new int[] {1, 1, 1, 1, 1, 1, 1, 1},
            new int[] {1, 0, 0, 0, 0, 0, 0, 1},
            new int[] {1, 0, 0, 0, 0, 0, 0, 1},
            new int[] {1, 0, 0, 0, 0, 0, 0, 1},
            new int[] {1, 0, 0, 0, 3, 0, 0, 1},
            new int[] {1, 0, 2, 0, 0, 0, 1, 1},
            new int[] {1, 0, 0, 0, 0, 0, 0, 1},
            new int[] {1, 1, 1, 1, 1, 1, 1, 1}
        };

        //For���̓�d���[�v�ɂ��C���X�^���X�̐���
        for (int i = 0; i < tileMap.Length; i++)
        {
            for (int j = 0; j < tileMap[i].Length; j++)
            {

                if (tileMap[i][j] == 0)
                {
                    //�w�i�𐶐�
                    Instantiate(bgPrefab, new Vector3(j, tileMap.Length - i, 0), Quaternion.identity);
                }
                if (tileMap[i][j] == 1)
                {
                    //�ǂ𐶐�
                    Instantiate(blockPrefab, new Vector3(j, tileMap.Length - i, 0), Quaternion.identity);
                }
                if (tileMap[i][j] == 2)
                {
                    //�L�����N�^�[�𐶐�
                    Instantiate(charactorPrefab, new Vector3(j, tileMap.Length - i, 0), Quaternion.identity);
                    //�L�����N�^�[�Əd�Ȃ镔���̔w�i�𐶐�
                    Instantiate(bgPrefab, new Vector3(j, tileMap.Length - i, 0), Quaternion.identity);
                }
                if (tileMap[i][j] == 3)
                {
                    //�A�C�e���𐶐�
                    Instantiate(ItemPrefab, new Vector3(j, tileMap.Length - i, 0), Quaternion.identity);
                    //�L�����N�^�[�Əd�Ȃ镔���̔w�i�𐶐�
                    Instantiate(bgPrefab, new Vector3(j, tileMap.Length - i, 0), Quaternion.identity);
                }
            }
        }
    }
}
