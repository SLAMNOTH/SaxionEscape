using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string sceneName;

    void OnTriggerEnter2D(Collider2D other)
{
    Debug.Log("Trigger entered!");
    if (other.CompareTag("Player"))
    {
        Debug.Log("Player detected!");
        SceneManager.LoadScene(sceneName);
    }
}

}
