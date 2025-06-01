using UnityEngine;
[DefaultExecutionOrder(100)]
public class GaugeController : MonoBehaviour
{
    [SerializeField] private GameObject gauge;
    [SerializeField] private GameObject graceGauge;
    private float _gaugeHeight;
    private float _minShotPower;

    public void SetPlayer(BallController ballController)
    {
        _minShotPower = ballController.MinShotPower;
        _gaugeHeight = gauge.GetComponent<RectTransform>().sizeDelta.y / (ballController.MaxShotPower - ballController.MinShotPower);
    }
    public void UpdateShotPowerGauge(float shotPower)
    {
        Vector2 nowSafes = gauge.GetComponent<RectTransform>().sizeDelta;
        nowSafes.y = (shotPower - _minShotPower) * _gaugeHeight;
        gauge.GetComponent<RectTransform>().sizeDelta = nowSafes;
    }
}
