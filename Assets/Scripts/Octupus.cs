using Random = System.Random;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class Octupus : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;

    private void Start()
    {
        health += getExtraHealth();
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
