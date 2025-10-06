using UnityEngine;

public class PokeFlute : MonoBehaviour
{
    public LayerMask layer;    
    private Vector3 previousPos;

    void Start()
    {
        previousPos = transform.position;
    }

    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 5f, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out hit, 5f, layer.value))
        {
            Vector3 swingDir = transform.position - previousPos;
            if (swingDir.magnitude > 0.05f && Vector3.Angle(swingDir, transform.forward) < 80f)
            {
                Destroy(hit.transform.gameObject);
            }

        }

        previousPos = transform.position;
    }
}
