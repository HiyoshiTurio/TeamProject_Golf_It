using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("�ړ��ݒ�")]
    [SerializeField] Vector3 moveOffset = new Vector3(0, 2f, 0); // �ړ������Ƌ����i�㉺�Ȃ�Y�A���E�Ȃ�X�j
    [SerializeField] float moveSpeed = 2f;      // �ړ����x
    [SerializeField] float waitTime = 1f;       // �[�ɓ��B�����Ƃ��̑ҋ@����

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool movingToTarget = true;
    private float waitTimer = 0f;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + moveOffset;
    }

    void Update()
    {
        if (waitTimer > 0f)
        {
            waitTimer -= Time.deltaTime;
            return;
        }
        //�ړI�n���w��
        Vector3 destination = movingToTarget ? targetPos : startPos;
        //�ړI�n�Ɉړ�
        transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, destination) < 0.01f)
        {
            movingToTarget = !movingToTarget;
            waitTimer = waitTime;
        }
    }
}

