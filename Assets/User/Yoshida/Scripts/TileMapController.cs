using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TileMapController : MonoBehaviour
{
    public static TileMapController instance;
    [SerializeField] Tilemap defaultTilemap;
    [SerializeField] Tilemap WallTilemap;
    [SerializeField] PlayerController Player;
    private Vector3Int beforePlayerCellPos;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    // Player�����݂���ʒu������o��
    public void CheckCloseDoor(Vector3 playerPos)
    {
        Vector3Int playerCellPos = defaultTilemap.WorldToCell(playerPos);
        if (beforePlayerCellPos != playerCellPos)
        {
            Goal(playerCellPos - Vector3Int.up);
            Goal(playerCellPos - Vector3Int.down);
            Goal(playerCellPos - Vector3Int.right);
            Goal(playerCellPos - Vector3Int.left);

            beforePlayerCellPos = playerCellPos;
        }
    }
    private void Goal(Vector3Int cellPos)
    {
        var tile = defaultTilemap.GetTile(cellPos);      
        if (tile && tile.name == "goal1")   // �^�C�����擾���A���O��goal1���A���[�v���������Ă����Ƃ��̂݃^�C�����폜
        {
            if (Player.ItemGet == true)
            {
                defaultTilemap.SetTile(cellPos, null);
            }               
        }
    }
}
