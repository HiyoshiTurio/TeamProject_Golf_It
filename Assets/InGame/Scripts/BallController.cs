using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float minSpeed = 0.1f; //MinSpeed以下になったら完全に静止する
    [SerializeField] private float maxShotPower = 20f;
    [SerializeField] private float minShotPower = 5f;
    [SerializeField] private GameObject directionIndicator; //ボールの向きを示すオブジェクト
    [SerializeField] private GameObject cameraLookObj;
    private Rigidbody _rb;
    private Camera _camera;
    private bool _isBallMoving = true;
    private bool _canShot = false;
    private float _timer = 0;
    private float _shotPower = 0f;
    
    public float MaxShotPower => maxShotPower;
    public float MinShotPower => minShotPower;
    public  event Action<float> UpdateBallPower;
    public Action OnBallShot;

    public float ShotPower
    {
        get { return _shotPower; }
        set
        {
            _shotPower = value;
            UpdateBallPower?.Invoke(_shotPower);
        }
    }

    public bool IsBallMoving
    {
        get { return _isBallMoving; }
        set
        {
            _isBallMoving = value;
            if(_isBallMoving) directionIndicator.SetActive(false);
            else directionIndicator.SetActive(true);
        }
    }


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
        
        if (IsBallMoving)
        {
            float moveSpeed = _rb.velocity.magnitude;
            if (moveSpeed < minSpeed)
            {
                IsBallMoving = false;
                _canShot = true;
                StopBall();
            }
        }
    }

    public void ShotBall()
    {
        if(!_canShot) return;
        Vector3 direction = _camera.transform.forward;
        direction.y = 0;
        direction.Normalize();
        _rb.AddForce(direction * ShotPower,ForceMode.Impulse);
        _canShot = false;
        Invoke("BallMoving", 0.1f);
        
        _timer = 0;
        ShotPower = 0f;
        OnBallShot?.Invoke();
    }

    public void ShotPowerRoulette()
    {
        if(!_canShot) return;
        _timer += Time.deltaTime;
        if (_timer > 1f)
            _timer -= 1f;
        var sin = Math.Sin(_timer * 90f * (Math.PI / 180f));
        float tmp = (maxShotPower - minShotPower) * (float)sin;
        ShotPower = minShotPower + tmp;
    }

    void BallMoving()
    {
        IsBallMoving = true;
    }

    void StopBall()
    {
        _rb.velocity = Vector3.zero;
    }
}
