using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SaberHit : MonoBehaviour
{

    private void Awake()
    {
        // make sure we detect triggers
        Collider col = GetComponent<Collider>();
        col.isTrigger = true;
        // Add a kinematic Rigidbody so triggers fire
        if (!TryGetComponent<Rigidbody>(out var rb))
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Destroy any object tagged as Target
        if (other.CompareTag("Target1") || other.CompareTag("Target2"))
        {
            Destroy(other.gameObject);
        }
    }
}