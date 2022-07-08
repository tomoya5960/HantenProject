using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StageSave : MonoBehaviour
{
    LoadOnlyJson loj;
    private void Start()
    {
        GeneralManager.instance.mapManager.stageData.Clear();
        loj = GetComponent<LoadOnlyJson>();
    }

    public void SaveTile()
    {
        foreach (var map in loj._mapData.Map.Select((mapChip, index) => new { mapChip, index }))
        {
            var tileData = loj.tileDataList[map.index].GetComponent<TileData>();
            var tileMaster = loj.tileDataList[map.index].GetComponent<TileMaster>();
            map.mapChip.mapImageID = tileData.imageID;
            map.mapChip.isEnableProceed = tileData.isEnableProceed;
            map.mapChip.isEnableRope = tileData.isEnableRope;
            map.mapChip.isEnableStone = tileData.isEnableStone;
            map.mapChip.isEnablePlayer = tileData.isEnablePlayer;
            map.mapChip.isSetAcctive = tileData.isactiveself;
            map.mapChip._turnFaceType = tileMaster._turnFaceType;
            map.mapChip.isEnableTurn = tileMaster.isEnableTurn;
        }
        var Json = JsonUtility.ToJson(loj._mapData, false); //まとめた情報をJsonに保存
        GeneralManager.instance.mapManager.stageData.Add(Json);
    }
    /// <summary> 
    /// 開始時にステージのJsonDataを呼び出す
    /// </summary>
    public void OnLoad()
    {
        loj._mapData = JsonUtility.FromJson<MapData>(GeneralManager.instance.mapManager.stageData[GeneralManager.instance.mapManager.TurnNum - 1]);
        LoadTile();
    }
    private void LoadTile()
    {
        foreach (var map in loj._mapData.Map.Select((mapChip, index) => new { mapChip, index }))
        {
            var tileData = loj.tileDataList[map.index].GetComponent<TileData>();
            var tileMaster = loj.tileDataList[map.index].GetComponent<TileMaster>();
            tileData.imageID = map.mapChip.mapImageID;
            tileData.isEnableProceed = map.mapChip.isEnableProceed;
            tileData.isEnableRope = map.mapChip.isEnableRope;
            tileData.isEnableStone = map.mapChip.isEnableStone;
            tileData.isEnablePlayer = map.mapChip.isEnablePlayer;
            Transform children = tileData.gameObject.transform.parent.GetComponentInChildren<Transform>();
            if (children.childCount != 0)
            {
                tileData.isactiveself = map.mapChip.isSetAcctive;
            }
            tileMaster._turnFaceType = map.mapChip._turnFaceType;
            tileMaster.mapImage.sprite = tileMaster.spriteLists[(int)tileMaster._turnFaceType];
            tileMaster._isEnableTurn =map.mapChip.isEnableTurn;
        }
    }
}
