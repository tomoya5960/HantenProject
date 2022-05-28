using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileMaster : MonoBehaviour
{
    private enum TurnFaceType   //現在のタイルの状態（表裏）
    {
        Front = 0,
        Back,
        Goal
    }
    [SerializeField]
    private List<Sprite> _spriteLists = new List<Sprite>(); //タイルのイメージ画像（表裏）

    private bool _isEnableTurn = true;  //現在のタイルが裏返せるかなー？（trueの時裏返すことが出来る）
    public bool IsEnableTurn => _isEnableTurn;  //外部から読み取り用のやーつ

    private bool _eternalTurn = false;  //のちほどカウントでできるようにintに変更すること

    private Image _mapImage = null;

    private TurnFaceType _turnFaceType = TurnFaceType.Front;    //生成されたときに表の状態にするよ
    public int EnableCount = 0; //反転できる残り回数

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="first">表の画像</param>
    /// <param name="second">裏の画像</param>
    public void InitSprite(Sprite first, Sprite second = null, Sprite third = null) //引数に = null があるのはなくても大丈夫なように！
    {
        _spriteLists.Add(first);    //表の画像を格納
        if (null != second) //表がinvisibleではなく裏がある場合
            _spriteLists.Add(second);
        if (null != third) //ゴールがある場合
            _spriteLists.Add(third);
        _mapImage.sprite = _spriteLists[(int)TurnFaceType.Front];   //表の画像をイメージを表示
    }

    /// <summary>
    /// 反転した時のイメージ変更
    /// </summary>
    public void TurnImage()
    {
        if (_isEnableTurn)   //反転することが出来る場合
        {
            if (EnableCount <= 0)   //残りの反転できる回数が０だった場合は反転できなくした後に何もせず返す
            {
                _isEnableTurn = false;
                return;
            }

            if (TurnFaceType.Front == _turnFaceType)    //現在のイメージが表と同じだったら（裏にひっくり返す場合）
            {
                _mapImage.sprite = _spriteLists[(int)TurnFaceType.Back];    //現在のイメージを裏の画像にする
                _turnFaceType = TurnFaceType.Back;  //現在の状態を裏にする
            }
            else  //現在のイメージが裏と同じだったら(表にひっくり返す場合) ※ゴール用
            {
                _mapImage.sprite = _spriteLists[(int)TurnFaceType.Front];   //現在のイメージを表の画像にする
                _turnFaceType = TurnFaceType.Front; //現在の状態を表にする
            } 
            EnableCount--;  //このタイルの反転できる回数を減らす
        }
    }
    public void GoolChange()
    {
        if (TurnFaceType.Front == _turnFaceType)    //表だった場合のみ読み込む　裏だと呼ばない　すでにクリア条件を満たしたゴールだった場合もよばない
        {
            if (_spriteLists.Count != 3) //三つ目の画像（クリア条件を満たした状態のゴールがある場合）がない場合
                return;
            else
            {
                _mapImage.sprite = _spriteLists[(int)TurnFaceType.Goal];    //現在のイメージをクリア条件を満たしたゴールの画像にする
            }
        }
    }
}
