using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor.Build;

//this script is for the player movement and other stuff
public class PlayerMovement : MonoBehaviour
{
    public float player_speed = 10.0f;
    public float min_y, max_y;
    public float attackTimer = 0.35f;
    private float currentAttackTimer;
    private bool canAttack;

    public float bulletSpeed = 20f;
    private Rigidbody2D rb;
    public GameObject playerBullet;
    public Transform firePoint;
    public Text healthText;
    public Text gameOverText;
    public Text scoreText;
    public GameObject shieldPrefab;
    public Text shieldText; 
    public Text shieldMessageText; 
    private GameObject currentShield;
    private int shieldHits = 0;
    public int health = 3;
    public int score = 0; 

    void Start()
    {
        currentAttackTimer = attackTimer;
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        MovePlayer();
        Attack();
        healthText.text = "Health: " + health;
        scoreText.text = "Score: " + score;
    }

    void Attack()
    {
        attackTimer += Time.deltaTime;
        if(attackTimer > currentAttackTimer)
        {
            canAttack = true;
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            if(canAttack)
            {
                canAttack = false;
                attackTimer = 0f;
                Instantiate(playerBullet, firePoint.position, Quaternion.identity);
            }
        }
    }

    void die()
    {
        gameOverText.text = "Game Over";
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(collision.gameObject);
            if (currentShield != null)
            {
                shieldHits++;
                if (shieldHits >= 4)
                {
                    Destroy(currentShield);
                    currentShield = null;
                    shieldText.text = "Shield: OFF";
                }
            }
            else
            {
                health--;
                healthText.text = "Health: " + health;
                if (health <= 0)
                {
                    die();
                }
            }
        }
        else if (collision.gameObject.CompareTag("BigAsteroid"))
        {
            Destroy(collision.gameObject);
            if (currentShield != null)
            {
                shieldHits++;
                if (shieldHits >= 4)
                {
                    Destroy(currentShield);
                    currentShield = null;
                    shieldText.text = "Shield: OFF";
                }
            }
            else
            {
                health--;
                score -= 5;
                healthText.text = "Health: " + health;
                scoreText.text = "Score: " + score;
                if (health <= 0)
                {
                    die();
                }
            }
        }
        else if (collision.gameObject.CompareTag("PowerUp")) 
        {
            Destroy(collision.gameObject);
            if (currentShield == null)
            {
                currentShield = Instantiate(shieldPrefab, transform.position, Quaternion.identity, transform);
                shieldHits = 0;
                health += 4;
                healthText.text = "Health: " + health;  
                StartCoroutine(ShowShieldMessage());
            }
        }
    }


    IEnumerator ShowShieldMessage()
    {
        shieldMessageText.text = "You got shield";
        yield return new WaitForSeconds(3);
        shieldMessageText.text = "";
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
    void MovePlayer()
    {
        if(Input.GetAxisRaw("Vertical") > 0f)
        {
            Vector3 temp = transform.position;
            temp.y += player_speed * Time.deltaTime;
            if(temp.y > max_y)
            {
                temp.y = max_y;
            }

            transform.position = temp;
        } else if(Input.GetAxisRaw("Vertical") < 0f)
        {
            Vector3 temp = transform.position;
            temp.y -= player_speed * Time.deltaTime;
            if(temp.y < min_y)
            {
                temp.y = min_y;
            }

            transform.position = temp;
        }
    }
}
