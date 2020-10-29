using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public PlayerMovement player;
    public float fireRate = 2.5f;
    float timeToShoot = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > timeToShoot)
        {
            Shoot();
            player.animator.SetTrigger("isShooting");
            player.animator.SetBool("Shoot", true);
            timeToShoot = Time.time + 1 / fireRate;
        }
        if(Input.GetButtonUp("Fire1"))
        {
            player.animator.SetBool("Shoot", false);
        }
            
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
