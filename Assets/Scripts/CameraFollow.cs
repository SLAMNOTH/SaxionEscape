using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Drag your player GameObject here
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        if (target != null)
        {
            // Keep the same y-coordinate as the camera's current position
            float newY = transform.position.y;

            // Calculate the desired position with the new y-coordinate
            Vector3 desiredPosition = new Vector3(target.position.x + offset.x, newY, transform.position.z);

            // Smoothly move the camera to the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
