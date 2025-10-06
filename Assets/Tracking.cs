using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleHMDTracking : MonoBehaviour
{
    [Header("Input Actions")]
    public InputActionProperty headPosition;
    public InputActionProperty headRotation;

    void Update()
    {
        if (headPosition != null && headPosition.action != null)
            transform.localPosition = headPosition.action.ReadValue<Vector3>();

        if (headRotation != null && headRotation.action != null)
            transform.localRotation = headRotation.action.ReadValue<Quaternion>();
    }
}
