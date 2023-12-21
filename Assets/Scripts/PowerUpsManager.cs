using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject powerUpPrefab;
    public int numberOfPowerUps = 5; // Set the desired number of power-ups

    void Start()
    {
        SpawnPowerUps();
    }

    void SpawnPowerUps()
    {
        for (int i = 0; i < numberOfPowerUps; i++)
        {
            // Adjust the spawn position based on your scene size
            Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-2f, 2f), 0f);

            // Instantiate power-up prefab and parent it to the "PowerUps" GameObject
            GameObject powerUp = Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity, transform);

            // Optionally, you can also set the power-up layer if needed
            // powerUp.layer = LayerMask.NameToLayer("PowerUp");
        }
    }
}
