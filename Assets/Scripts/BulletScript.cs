using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is a script that defines a bullet
public class BulletScript : MonoBehaviour
{
    public float speed = 5f;
    public float deactivate_timer = 3f;
    public Rigidbody2D rb;
    void Start()
    {
        Invoke("DeactivateGameObject", deactivate_timer);
        rb.velocity = transform.right * speed;
    }
    void Update()
    {
        Move();
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }
    void Move()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid") || collision.gameObject.CompareTag("BigAsteroid"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.IncrementScore();
            }
        }
        else if (collision.gameObject.CompareTag("PowerUp"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
}
