using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float shotPower = 10;
    [SerializeField] float minSpeed = 0.1f; //MinSpeed以下になったら完全に静止する
    [SerializeField] GameObject directionIndicator; //ボールの向きを示すオブジェクト
    [SerializeField] private GameObject cameraLookObj;
    private Rigidbody _rb;
    private Camera _camera;
    private bool _isBallMoving = true;
    private bool _canShot = false;
    
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

    public bool CanShot => _canShot;

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
            if (moveSpeed < 0.1f)
            {
                IsBallMoving = false;
                _canShot = true;
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
        _canShot = false;
        Invoke("BallMoving", 0.1f);
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
