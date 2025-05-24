using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//�Q�[���V�X�e���N���X
public class GameSystem : MonoBehaviour
{
    [SerializeField, Header("��������")] private float _timeLimit = 1.0f;

    [SerializeField, Header("�Q�[���I�[�o�[�̃C�x���g")]
    private UnityEvent _eventOnGO;

    //�X�R�A�≽���ł����̃X�R�A

    private float _score;

    private int _dasuu;

    //��邱�Ǝu�c�^���X�R�A�ƑŐ��\���p�Ƀ��\�b�h���C�x���g�ɓo�^����i�悭�����ł��ĂȂ��j��������炵���̂ł�����
    //�̓C�x���g��`���Ĕ��΁H�i�Ȃ�┭�΂��āj�͂������ł�����
    //������ҁ[�ɕ������瑽������ȓz���Ǝv��

    //�X�R�A�ύX�C�x���g��`�ifloat = �V�����X�R�A�j
    public static event Action<float> OnScoreChanged;
    //�Ő��ύX�C�x���g��`�iint = �V�����Ő��j
    public static event Action<int> OnDasuuChanged;

    //���̃C�x���g�����Ȃ������ȕ׋��ɂȂ��B

    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {

    }
    public void AddScore(float amount)
    {
        _score += amount;

        //�����Ŕ��΃X�R�A
        OnScoreChanged?.Invoke(_score);
    }

    public void AddDasuu(int amount)
    {
        _dasuu += amount;

        //�����Ŕ��ΑŐ�
        OnDasuuChanged?.Invoke(_dasuu);

    }
}