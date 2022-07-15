using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationControl : MonoBehaviour
{
    [System.Serializable]
    public class CharacterAnimationSprites
    {
        [SerializeField]
        //  �A�j���[�V��������X�v���C�g
        public List<Sprite> AnimationSprites = new List<Sprite>();
    }
    public enum CharacterDirectionType
    {
        Up = 0,
        Down,
        Left,
        Right,
        none,
    }
    [SerializeField]
    private List<CharacterAnimationSprites> _animationSprites = new List<CharacterAnimationSprites>();
    private bool isSpriteChengeOn = false;
    [SerializeField]
    private float _waitTime = 0.01f;

    private Sprite _characterSprite = null;

    //  �A�C�h�����O��ԃt���O
    private bool _isIdle = false;
    //  �L�����N�^�̌���
    private CharacterDirectionType _characterDirectionType = CharacterDirectionType.Down;

    //  �A�C�h�����O��Ԃ̃X�v���C�g�C���f�b�N�X�ԍ����X�g
    private List<int> _idleIndexLists = new List<int>() { 0, 7, 14, 21 };
    //  ���ݍĐ����̃X�v���C�g�C���f�b�N�X
    private int _animationPoseIndex = 0;
    //  �A�C�h�����O��Ԃ̃X�v���C�g�C���f�b�N�X�ԍ�
    private const int _idleIndex = 1;
    //  �ő�C���f�b�N�X��
    private const int _animationMaxIndex = 4;

    private List<int> _animationTable = new List<int>() { 1, 0, 1, 2 };

    private void Awake()
    {
        _characterSprite = GetComponent<SpriteRenderer>().sprite;
    }

    /// <summary>
    /// �ړ����[�h�̐ݒ�
    /// </summary>
    /// <param name="isIdle">�A�C�h�����O�Ȃ� true</param>
    /// <param name="characterDirectionType">�ړ�����</param>
    public void SetActionMode(bool isIdle, CharacterDirectionType characterDirectionType = CharacterDirectionType.none)
    {
        _isIdle = isIdle;
        //  �ړ��������w�肳��Ă����炻�̕����Ɍ���
        if (CharacterDirectionType.none != characterDirectionType)
            _characterDirectionType = characterDirectionType;
        //  �A�C�h�����O�Ȃ��~�摜�ɕύX
        if (_isIdle)
        {
            _characterSprite = _animationSprites[(int)_characterDirectionType].AnimationSprites[_idleIndex];
        }
        //  �A�j���[�V�����J�n
        else
        {
            _animationPoseIndex = 0;
            _characterSprite = _animationSprites[(int)_characterDirectionType].AnimationSprites[_animationPoseIndex];
            StartCoroutine(CharacterAnimation());
        }
    }
    /// <summary>
    /// �L�����N�^�[�A�j���[�V�����̃R���[�`��
    /// </summary>
    /// <returns></returns>
    private IEnumerator CharacterAnimation()
    {
        if (isSpriteChengeOn) { yield break; }
        isSpriteChengeOn = true;
        //  �A�C�h�����O�ɂȂ�܂ŌJ��Ԃ�
        while (!_isIdle)
        {
            //  �w�莞�Ԃ̑ҋ@
            yield return new WaitForSeconds(_waitTime);
            //  �|�[�Y�C���f�b�N�X�̉��Z
            _animationPoseIndex++;
            //  �A�j���[�V�����e�[�u�����𒴂��Ȃ��悤�ɂ���
            _animationPoseIndex %= _animationMaxIndex;
            //  ���ۂ̃C���f�b�N�X���擾����
            var index = _animationTable[_animationPoseIndex];
            //  �A�j���[�V�����̃C���[�W������������B
            _characterSprite = _animationSprites[(int)_characterDirectionType].AnimationSprites[index];
            GetComponent<SpriteRenderer>().sprite = _characterSprite;
        }
        isSpriteChengeOn = false;
    }
}
