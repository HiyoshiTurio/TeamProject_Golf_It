using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//ゲームシステムクラス
public class GameSystem : MonoBehaviour
{
    [SerializeField, Header("制限時間")] private float _timeLimit = 1.0f;

    [SerializeField, Header("制限打数（規定打数）でゲームオーバー")] private int _Maxdasuu = 12;
    //勝手に書き変わらないようにする
    public static GameSystem Instance { get; private set; }

    //（　＾ω＾）・・・ココで使ってるやんevent…
    [SerializeField, Header("ゲームオーバーのイベント")]
    private UnityEvent _eventOnGO;

    //スコアや何手を打ったのスコア

    private float _score;

    private int _dasuu;

    private bool _gameover;

    //やること志慶真がスコアと打数表示用にメソッドをイベントに登録する（よく理解できてない）を作ったらしいのでこっち
    //はイベント定義して発火？（なんや発火って）はこっちでやるって
    //ちゃっぴーに聞いたら多分こんな奴だと思う

    //スコア変更イベント定義（float = 新しいスコア）
    public event Action<float> OnScoreChanged;
    //打数変更イベント定義（int = 新しい打数）
    public event Action<int> OnDasuuChanged;
    //ゲームオーバーのイベント定義
    public event Action<bool> OnGameOverChanged;

    //このイベントしたなかったな勉強になた。
    //プレイヤーが打数のやつ読んでくれるからこっちで制限をする


    //ランキングの実装
    //上位ｘ名残す
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
        //スコアをマイナスするときマイナスにならないようにする
        if (_score < 0)
        {
            _score = 0;
        }
        //ここで発火スコア
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
        //ここで発火打数
        OnDasuuChanged?.Invoke(_dasuu);
        OnGameOverChanged?.Invoke(_gameover);

    }


    //ランキングの保存
    public void SaveScoreToRanking()
    {
        List<float> ranking = LoadRanking();
        ranking.Add(_score);
        ranking.Sort((a, b) => b.CompareTo(a));
        //上位のｘ件に
        if (ranking.Count > MaxRankingCount)
        {
            ranking = ranking.GetRange(0, MaxRankingCount);
        }

        //保存
        for (int i = 0; i < ranking.Count; i++)
        {
            PlayerPrefs.SetFloat($"Ranking_{i}", ranking[i]);
        }
        PlayerPrefs.Save();
    }
    //ランキングの取得
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
