using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("移動設定")]
    [SerializeField] Vector3 moveOffset = new Vector3(0, 2f, 0); // 移動方向と距離（上下ならY、左右ならX）
    [SerializeField] float moveSpeed = 2f;      // 移動速度
    [SerializeField] float waitTime = 1f;       // 端に到達したときの待機時間

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
        //目的地を指定
        Vector3 destination = movingToTarget ? targetPos : startPos;
        //目的地に移動
        transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, destination) < 0.01f)
        {
            movingToTarget = !movingToTarget;
            waitTimer = waitTime;
        }
    }
}

