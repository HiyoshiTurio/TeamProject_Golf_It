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



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
