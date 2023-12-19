using UnityEngine;

public class PersistentManager : MonoBehaviour
{
    public static int selectedLevelIndex = 0; // Default level index

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
