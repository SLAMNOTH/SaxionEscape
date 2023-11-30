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
        Debug.Log("Target position: " + target.position);

        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}

}
