using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is for the power up
public class Powerup : MonoBehaviour
{
    public float speed = 2.0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * speed;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
