using UnityEngine;
using UnityEngine.SceneManagement;

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

            // Get the current scene
            Scene currentScene = SceneManager.GetActiveScene();

            // Check the scene name and adjust camera behavior accordingly
            if (currentScene.name == "Level1")
            {
                // Only follow on the x-axis
                Vector3 desiredPosition = new Vector3(target.position.x + offset.x, newY, transform.position.z);
                SmoothlyMoveToPosition(desiredPosition);
            }
            else if (currentScene.name == "Level2")
            {
                // Follow on both x and y axes
                Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);
                SmoothlyMoveToPosition(desiredPosition);
            }
        }
    }

    // Function to smoothly move the camera to the desired position
    void SmoothlyMoveToPosition(Vector3 desiredPosition)
    {
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
