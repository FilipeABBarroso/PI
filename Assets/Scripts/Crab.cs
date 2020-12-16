using System.Collections;
using UnityEngine;
using Random = System.Random;

public class Crab : MonoBehaviour
{
    public int health = 100;
    public float speed;
    public int damage = 20;
    float timeToTurn = 0f;

    public GameObject deathEffect;
    public Transform groundCheck;
    public Collider2D bodyCollider;
    public LayerMask groundLayer, EnemyLayer;

    private bool movingRight = false;

    private void Start()
    {
        health += getExtraHealth();
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, 1f);
        if (groundInfo.collider == false || bodyCollider.IsTouchingLayers(groundLayer) || bodyCollider.IsTouchingLayers(EnemyLayer))
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        turn();
    }

    void turn()
    {
        if (Time.time > timeToTurn + 5)
        {
            timeToTurn = Time.time;
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(effect, 0.45f);
    }

    private int getExtraHealth()
    {
        Random r = new Random();
        double v = r.NextDouble();
        if (v <= 0.3) return 0;
        else if (0.3 < v && v <= 0.6) return 20;
        else if (0.6 < v && v <= 0.8) return 40;
        else if (0.8 < v && v <= 0.95) return 60;
        else return 90;
    }

}
