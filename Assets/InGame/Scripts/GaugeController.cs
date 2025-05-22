using UnityEngine;

public class GaugeController : MonoBehaviour
{
    [SerializeField] private GameObject gauge;
    [SerializeField] private GameObject graceGauge;
    [SerializeField] private BallController ballController;
    private float _gaugeHeight;

    private void Start()
    {
        _gaugeHeight = gauge.GetComponent<RectTransform>().sizeDelta.y / (ballController.MaxShotPower - ballController.MinShotPower);
        ballController.UpdateBallPower += UpdateShotPowerGauge;
    }
    void UpdateShotPowerGauge(float shotPower)
    {
        Vector2 nowSafes = gauge.GetComponent<RectTransform>().sizeDelta;
        nowSafes.y = (shotPower - ballController.MinShotPower) * _gaugeHeight;
        gauge.GetComponent<RectTransform>().sizeDelta = nowSafes;
    }
}
