using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is about the asteroids
public class Asteroids : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float speed = 2.0f; 

    private void Start()
    {
        InvokeRepeating("SpawnAsteroid", 5.0f, 3f);
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    private void SpawnAsteroid()
    {
        float randomYPosition = Random.Range(-5.0f, 5.0f);
        Vector2 spawnPosition = new Vector2(10, randomYPosition);
        Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject); 
    }

}