using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    public GameObject deathEffect;
    Rigidbody2D rb;
    Color c;
    Renderer rend;
    public HealthBar healthBar;

    public int health = 100;
    float horizontalMove = 0f;
    public float runSpeed;
    private float currentSpeed;
    

    bool gotHurt;
    bool jump = false;
    bool crouch = false;

    void Start()
    {
        healthBar.SetMaxHealth(health);
        rend = GetComponent<Renderer>();
        c = rend.material.color;
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = runSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * currentSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            currentSpeed = 0f;

        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            currentSpeed = runSpeed;
        }
    }

    void FixedUpdate()
    {
        if (!gotHurt)
        {
            currentSpeed = runSpeed;
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
            jump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("crab"))
        {
            Crab crab = new Crab();
            TakeDamage(crab.damage);
            Destroy(crab);
            animator.SetTrigger("gotHurt");
            StartCoroutine("Hurt");
            StartCoroutine("Invunerable");
        }
        if (collision.gameObject.tag.Equals("octupus"))
        {
            OctupusBullet oB = new OctupusBullet();
            TakeDamage(oB.damage);
            Destroy(oB);
            animator.SetTrigger("gotHurt");
            StartCoroutine("Hurt");
            StartCoroutine("Invunerable");
        }
    }


    public IEnumerator Invunerable()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        Physics2D.IgnoreLayerCollision(10, 12, true);
        c.a = 0.5f;
        rend.material.color = c;
        yield return new WaitForSeconds(3f);
        Physics2D.IgnoreLayerCollision(10, 11, false);
        Physics2D.IgnoreLayerCollision(10, 12, false);
        c.a = 1f;
        rend.material.color = c;
    }

    public IEnumerator Hurt()
    {
        gotHurt = true;
        currentSpeed = 0f;

        if (controller.m_FacingRight)
            rb.AddForce(new Vector2(-300f, 200f));
        else
            rb.AddForce(new Vector2(300f, 200f));

        yield return new WaitForSeconds(0.5f);
        gotHurt = false;
    }

    public void onCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }

    public void onLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.setHealth(health);
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
}
