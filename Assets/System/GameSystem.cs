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



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
