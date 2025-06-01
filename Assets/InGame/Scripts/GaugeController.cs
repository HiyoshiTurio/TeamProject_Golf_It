using UnityEngine;
[DefaultExecutionOrder(100)]
public class GaugeController : MonoBehaviour
{
    [SerializeField] private GameObject gauge;
    [SerializeField] private GameObject graceGauge;
    InGameManager _inGameManager;
    private float _gaugeHeight;
    private float _minShotPower;

    private void Awake()
    {
        _inGameManager = InGameManager.Instance;
    }

    private void Start()
    {
        BallController ballController = _inGameManager.ballController;
        _minShotPower = ballController.MinShotPower;
        _gaugeHeight = gauge.GetComponent<RectTransform>().sizeDelta.y / (ballController.MaxShotPower - ballController.MinShotPower);
        _inGameManager.UpdateBallPower += UpdateShotPowerGauge;
    }
    public void UpdateShotPowerGauge(float shotPower)
    {
        Vector2 nowSafes = gauge.GetComponent<RectTransform>().sizeDelta;
        nowSafes.y = (shotPower - _minShotPower) * _gaugeHeight;
        gauge.GetComponent<RectTransform>().sizeDelta = nowSafes;
    }
}
