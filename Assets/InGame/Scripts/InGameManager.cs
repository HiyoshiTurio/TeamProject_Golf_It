using Cinemachine;
using UnityEngine;
using System;

[DefaultExecutionOrder(-100)]
public class InGameManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject playerSpawnPoint;
    public GaugeController gaugeController;
    public PlayerSound playerSound;
    static InGameManager _instance;
    public BallController ballController;
    public Action<float> UpdateBallPower;
    public Action OnBallShot;
    public static InGameManager Instance => _instance;

    private void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        GameObject player = Instantiate(playerPrefab, playerSpawnPoint.transform.position, transform.rotation);
        
        virtualCamera.Follow = player.GetComponent<BallController>().CameraLookObj.transform;
    }
}