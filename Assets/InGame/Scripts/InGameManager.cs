using Cinemachine;
using UnityEngine;
using System;
public class InGameManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] GaugeController gaugeController;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] PlayerSound playerSound;
    static InGameManager _instance;
    private BallController _ballController;
    public Action<float> UpdateBallPower;
    public Action OnBallShot;
    public static InGameManager Instance => _instance;
    public BallController BallController => _ballController;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        _ballController = playerPrefab.GetComponent<BallController>();
        GameObject player = Instantiate(playerPrefab, transform.position, transform.rotation);
        virtualCamera.Follow = player.GetComponent<BallController>().CameraLookObj.transform;
        
        gaugeController.SetPlayer(_ballController);
        UpdateBallPower += gaugeController.UpdateShotPowerGauge;
    }
}
