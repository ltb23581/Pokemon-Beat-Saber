using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleHandTracking : MonoBehaviour
{
    [Header("Input Actions")]
    public InputActionProperty positionAction;
    public InputActionProperty rotationAction;

    void OnEnable()
    {
        if (positionAction != null && positionAction.action != null)
            positionAction.action.Enable();

        if (rotationAction != null && rotationAction.action != null)
            rotationAction.action.Enable();
    }

    void OnDisable()
    {
        if (positionAction != null && positionAction.action != null)
            positionAction.action.Disable();

        if (rotationAction != null && rotationAction.action != null)
            rotationAction.action.Disable();
    }

    void Update()
    {
        if (positionAction != null && positionAction.action != null)
            transform.localPosition = positionAction.action.ReadValue<Vector3>();

        if (rotationAction != null && rotationAction.action != null)
            transform.localRotation = rotationAction.action.ReadValue<Quaternion>();
    }
}
