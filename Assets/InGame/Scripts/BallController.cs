using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float shotPower = 10;
    [SerializeField] float minSpeed = 0.1f; //MinSpeed以下になったら完全に静止する
    [SerializeField] GameObject directionIndicator; //ボールの向きを示すオブジェクト
    [SerializeField] private GameObject cameraLookObj;
    private Rigidbody _rb;
    private Camera _camera;
    private bool _isBallMoving = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector3 direction = _camera.transform.forward;
        direction.y = 0;
        direction.Normalize();
        directionIndicator.transform.forward = direction;
        cameraLookObj.transform.position = transform.position;
        cameraLookObj.transform.position += new Vector3(0, 1.2f, 0);
        if (!_isBallMoving)
        {
            float moveSpeed = _rb.velocity.magnitude;
            if (moveSpeed < 0.1f)
            {
                _isBallMoving = true;
                StopBall();
            }
        }
    }

    public void ShotBall()
    {
        Vector3 direction = _camera.transform.forward;
        direction.y = 0;
        direction.Normalize();
        _rb.AddForce(direction * shotPower,ForceMode.Impulse);
    }

    void StopBall()
    {
        _rb.velocity = Vector3.zero;
    }
}
