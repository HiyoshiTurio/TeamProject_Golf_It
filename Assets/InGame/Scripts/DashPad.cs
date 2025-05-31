using UnityEngine;

public class DashPad : MonoBehaviour
{
    [Header("‰Á‘¬‚Ìİ’è")]
    public Vector3 dashDirection = Vector3.forward; // ‰Á‘¬‚·‚é•ûŒü
    public float dashForce = 20f;                   // ‰Á‘¬‚Ì‹­‚³

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 force = dashDirection.normalized * dashForce;
            rb.AddForce(force, ForceMode.Impulse); // ˆêu‚Å‰Á‘¬I
        }
    }
}
