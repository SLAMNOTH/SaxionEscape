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

            // Check the current scene level
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;

            // Calculate the desired position based on the scene level
            Vector3 desiredPosition;
            if (sceneName == "Level1")
            {
                // Follow only on the x-axis
                desiredPosition = new Vector3(target.position.x + offset.x, newY, transform.position.z);
            }
            else if (sceneName == "Level2")
            {
                // Follow on both x and y axes
                desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);
            }
            else
            {
                // Default behavior
                desiredPosition = new Vector3(target.position.x + offset.x, newY, transform.position.z);
            }

            // Smoothly move the camera to the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
