using System.Collections;
using UnityEngine;

public class OctupusBullet: MonoBehaviour
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
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(Damage);
        }
        GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(effect, 0.35f);
    }
}
