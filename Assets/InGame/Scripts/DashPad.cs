using UnityEngine;

public class DashPad : MonoBehaviour
{
    [Header("加速の設定")]
    public Vector3 dashDirection = Vector3.forward; // 加速する方向
    public float dashForce = 20f;                   // 加速の強さ

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 force = dashDirection.normalized * dashForce;
            rb.AddForce(force, ForceMode.Impulse); // 一瞬で加速！
        }
    }
}
