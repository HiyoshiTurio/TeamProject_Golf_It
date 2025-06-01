using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float minSpeed = 0.1f; //MinSpeed以下になったら完全に静止する
    [SerializeField] private float maxShotPower = 20f;
    [SerializeField] private float minShotPower = 5f;
    [SerializeField] private GameObject directionIndicator; //ボールの向きを示すオブジェクト
    [SerializeField] private GameObject cameraLookObj;
    [SerializeField] private float ballStopTime = 1f;
    private InGameManager _inGameManager;
    private GameSystem _gameSystem;
    private Rigidbody _rb;
    private Camera _camera;
    Vector3 _lastPosition;
    private bool _isBallMoving = true;
    private float _timer = 0;
    private float _shotPower = 0f;
    private float _ballStopTimer = 0f;
    
    public float MaxShotPower => maxShotPower;
    public float MinShotPower => minShotPower;
    public GameObject CameraLookObj => cameraLookObj;
    public float ShotPower
    {
        get { return _shotPower; }
        set
        {
            _shotPower = value;
            InGameManager.Instance.UpdateBallPower?.Invoke(_shotPower);
        }
    }

    public bool IsBallMoving
    {
        get { return _isBallMoving; }
        set
        {
            _isBallMoving = value;
            if (_isBallMoving) directionIndicator.SetActive(false);
            else directionIndicator.SetActive(true);
        }
    }
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _camera = Camera.main;
        
        _inGameManager = InGameManager.Instance;
        _inGameManager.ballController = this;
        
        _gameSystem = GameSystem.Instance;
    }

    private void Start()
    {
        _inGameManager = InGameManager.Instance;
    }

    private void Update()
    {
        Vector3 direction = _camera.transform.forward;
        direction.y = 0;
        direction.Normalize();
        directionIndicator.transform.forward = direction;
        cameraLookObj.transform.position = transform.position;
        cameraLookObj.transform.position += new Vector3(0, 0.02f, 0);
        CheckBallMoving();
    }

    public void ShotBall()
    {
        if(IsBallMoving) return;
        _lastPosition = transform.position;
        _rb.isKinematic = false;
        Vector3 direction = _camera.transform.forward;
        direction.y = 0;
        direction.Normalize();
        _rb.AddForce(direction * ShotPower,ForceMode.Impulse);
        IsBallMoving = true;
        
        _timer = 0;
        ShotPower = 0f;
        InGameManager.Instance.OnBallShot?.Invoke();
        _gameSystem.AddDasuu(1);
    }

    public void ShotPowerRoulette()
    {
        if(_isBallMoving) return;
        _timer += Time.deltaTime;
        if (_timer > 1f)
            _timer -= 1f;
        var sin = Math.Sin(_timer * 90f * (Math.PI / 180f));
        float tmp = (maxShotPower - minShotPower) * (float)sin;
        ShotPower = minShotPower + tmp;
    }

    void StopBall()
    {
        _rb.velocity = Vector3.zero;
        _rb.isKinematic = true;
    }

    void CheckBallMoving()
    {
        if (IsBallMoving)
        {
            if (_rb.velocity.magnitude < minSpeed)
            {
                _ballStopTimer += Time.deltaTime;
                if (_ballStopTimer > ballStopTime)
                {
                    _ballStopTimer = 0f;
                    IsBallMoving = false;
                    StopBall();
                }
            }
        }
    }

    void CourseOut()
    {
        StopBall();
        transform.position = _lastPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CourseOutCollision"))
        {
            CourseOut();
        }

        if (other.CompareTag("Goal"))
        {
            Debug.Log("Goal");
        }
    }
}
