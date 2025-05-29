using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//�Q�[���V�X�e���N���X
public class GameSystem : MonoBehaviour
{
    [SerializeField, Header("��������")] private float _timeLimit = 1.0f;

    [SerializeField, Header("�����Ő��i�K��Ő��j�ŃQ�[���I�[�o�[")] private int _Maxdasuu = 12;
    //����ɏ����ς��Ȃ��悤�ɂ���
    public static GameSystem Instance { get; private set; }

    //�i�@�O�ցO�j�E�E�E�R�R�Ŏg���Ă���event�c
    [SerializeField, Header("�Q�[���I�[�o�[�̃C�x���g")]
    private UnityEvent _eventOnGO;

    //�X�R�A�≽���ł����̃X�R�A

    private float _score;

    private int _dasuu;

    private bool _gameover;

    //��邱�Ǝu�c�^���X�R�A�ƑŐ��\���p�Ƀ��\�b�h���C�x���g�ɓo�^����i�悭�����ł��ĂȂ��j��������炵���̂ł�����
    //�̓C�x���g��`���Ĕ��΁H�i�Ȃ�┭�΂��āj�͂������ł�����
    //������ҁ[�ɕ������瑽������ȓz���Ǝv��

    //�X�R�A�ύX�C�x���g��`�ifloat = �V�����X�R�A�j
    public event Action<float> OnScoreChanged;
    //�Ő��ύX�C�x���g��`�iint = �V�����Ő��j
    public event Action<int> OnDasuuChanged;
    //�Q�[���I�[�o�[�̃C�x���g��`
    public event Action<bool> OnGameOverChanged;

    //���̃C�x���g�����Ȃ������ȕ׋��ɂȂ��B
    //�v���C���[���Ő��̂�ǂ�ł���邩�炱�����Ő���������


    //�����L���O�̎���
    //��ʂ����c��
    const int MaxRankingCount = 5;

    void Awake()
    {
        Instance = this;
    }

    public void ResetScore()
    {
        _score = 0;
        _dasuu = 0;
        OnScoreChanged?.Invoke(_score);
        OnDasuuChanged?.Invoke(_dasuu);

    }

    public void AddScore(float amount)
    {
        _score += amount;
        //�X�R�A���}�C�i�X����Ƃ��}�C�i�X�ɂȂ�Ȃ��悤�ɂ���
        if (_score < 0)
        {
            _score = 0;
        }
        //�����Ŕ��΃X�R�A
        OnScoreChanged?.Invoke(_score);
    }

    //public void SubtractScore(float amount)
    //{
    //    _score -= amount;
    //    if (_score < 0) _score = 0;
    //    OnScoreChanged?.Invoke(_score);
    //}
    public void AddDasuu(int amount)
    {
        _dasuu += amount;
        if (_dasuu < _Maxdasuu)
        {
            _gameover = true;
        }
        //�����Ŕ��ΑŐ�
        OnDasuuChanged?.Invoke(_dasuu);
        OnGameOverChanged?.Invoke(_gameover);

    }


    //�����L���O�̕ۑ�
    public void SaveScoreToRanking()
    {
        List<float> ranking = LoadRanking();
        ranking.Add(_score);
        ranking.Sort((a, b) => b.CompareTo(a));
        //��ʂ̂�����
        if (ranking.Count > MaxRankingCount)
        {
            ranking = ranking.GetRange(0, MaxRankingCount);
        }

        //�ۑ�
        for (int i = 0; i < ranking.Count; i++)
        {
            PlayerPrefs.SetFloat($"Ranking_{i}", ranking[i]);
        }
        PlayerPrefs.Save();
    }
    //�����L���O�̎擾
    public List<float> LoadRanking()
    {
        List<float> ranging = new List<float>();

        for (int i = 0; i < MaxRankingCount; i++)
        {
            if (PlayerPrefs.HasKey($"Ranking_{i}"))
            {
                float score = PlayerPrefs.GetFloat($"Ranking_{i}");
                ranging.Add(score);
            }
        }
        return ranging;

    }
}
