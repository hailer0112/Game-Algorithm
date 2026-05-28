using UnityEngine;

using UnityEngine.InputSystem;
public class QuaternionInputGizmoPractice : MonoBehaviour
{
    public float rotationSpeed = 4f;
    public float targetMoveSpeed = 4f;
    public float targetDistance = 4f;
    public float targetRange = 3f;

    Vector3 targetOffset = new Vector3(0f, 0f, 4f);
    void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null )
        {
            return;
        }

        Vector2 input = Vector2.zero;

        if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
        {
            input.x -= 1f;
        }
        if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed)
        {
            input.x += 1f;
        }
        if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed)
        {
            input.y -= 1f;
        }
        if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed)
        {
            input.y += 1f;
        }

        if (keyboard.spaceKey.wasPressedThisFrame)
        {
            targetOffset = new Vector3(0f, 0f, targetDistance);
        }

        targetOffset += new Vector3(input.x, input.y, 0f) * targetMoveSpeed * Time.deltaTime;
        targetOffset.x = Mathf.Clamp(targetOffset.x, -targetRange, targetRange);
        targetOffset.y = Mathf.Clamp(targetOffset.y, -targetRange, targetRange);
        targetOffset.z = targetDistance;

        Vector3 targetDirection = targetOffset.normalized;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed *  Time.deltaTime);
    }
    void OnDrawGizmos()
    {
        Vector3 origin = transform.position;
        Vector3 targetPosition = origin + targetOffset;
        Vector3 targetDirection = targetOffset.normalized;

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(targetPosition, 0.15f);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(origin, origin + transform.forward * targetDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(origin, origin + targetDirection * targetDistance);
    }
}
