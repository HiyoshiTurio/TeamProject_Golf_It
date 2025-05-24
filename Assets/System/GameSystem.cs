using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//ゲームシステムクラス
public class GameSystem : MonoBehaviour
{
    [SerializeField, Header("制限時間")] private float _timeLimit = 1.0f;

    [SerializeField, Header("ゲームオーバーのイベント")]
    private UnityEvent _eventOnGO;

    //スコアや何手を打ったのスコア

    private float _score;

    private int _dasuu;

    //やること志慶真がスコアと打数表示用にメソッドをイベントに登録する（よく理解できてない）を作ったらしいのでこっち
    //はイベント定義して発火？（なんや発火って）はこっちでやるって
    //ちゃっぴーに聞いたら多分こんな奴だと思う

    //スコア変更イベント定義（float = 新しいスコア）
    public static event Action<float> OnScoreChanged;
    //打数変更イベント定義（int = 新しい打数）
    public static event Action<int> OnDasuuChanged;

    //このイベントしたなかったな勉強になた。

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

        //ここで発火スコア
        OnScoreChanged?.Invoke(_score);
    }

    public void AddDasuu(int amount)
    {
        _dasuu += amount;

        //ここで発火打数
        OnDasuuChanged?.Invoke(_dasuu);

    }
}