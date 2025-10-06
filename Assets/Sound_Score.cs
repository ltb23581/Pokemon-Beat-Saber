using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SaberSoundScore : MonoBehaviour
{
    public string saberType = "Red";
    public int points = 100;

    public AudioClip goodHitSound;
    public AudioClip badHitSound;

    private AudioSource audioSource;

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
        if (other.CompareTag("Target1") && saberType == "Red")
        {
            ScoreManager.Instance.AddScore(points);
            AudioSource.PlayClipAtPoint(goodHitSound, transform.position);

        } else if (other.CompareTag("Target2") && saberType == "White")
        {
            ScoreManager.Instance.AddScore(points);
            AudioSource.PlayClipAtPoint(goodHitSound, transform.position);
        }
        else if((other.CompareTag("Target1") && saberType == "White") || (other.CompareTag("Target2") && saberType == "Red"))
        {
            AudioSource.PlayClipAtPoint(badHitSound, transform.position);
        }
    }
}