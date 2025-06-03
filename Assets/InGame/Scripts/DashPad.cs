using UnityEngine;

public class DashPad : MonoBehaviour
{
    [Header("�����̐ݒ�")]
    public Vector3 dashDirection = Vector3.forward; // �����������
    public float dashForce = 20f;                   // �����̋���

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 force = dashDirection.normalized * dashForce;
            rb.AddForce(force, ForceMode.Impulse); // ��u�ŉ����I
        }
    }
}
