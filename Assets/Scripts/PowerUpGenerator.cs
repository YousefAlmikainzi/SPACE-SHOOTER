using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is how the power up generator again
public class PowerUpGenerator : MonoBehaviour
{
    public GameObject power_up_prefab;
    public float spawnDelay = 10f;
    private bool powerUpSpawned = false;

    void Start()
    {
        Invoke("SpawnPowerUp", spawnDelay);
    }

    void SpawnPowerUp()
    {
        if (!powerUpSpawned)
        {
            float randomYPosition = Random.Range(-4.5f, 4.5f);
            Vector2 spawnPosition = new Vector2(10, randomYPosition);
            Instantiate(power_up_prefab, spawnPosition, Quaternion.identity);
            powerUpSpawned = true;
        }
    }
}
