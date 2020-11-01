using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 20f;
    public int Damage = 40;
    public GameObject impactEffect;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * Speed;    
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Octupus octupus = hitInfo.GetComponent<Octupus>();
        Crab crab = hitInfo.GetComponent<Crab>();
        if(crab != null)
        {
            crab.TakeDamage(Damage);
        }
        if(octupus != null)
        {
            octupus.TakeDamage(Damage);
        }
        GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(effect, 0.35f);
    }
}
