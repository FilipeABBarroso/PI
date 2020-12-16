using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform enemyFirePoint;
    public GameObject bulletPrefab;
    public float fireRate = 2.5f;
    float timeToShoot = 0f;

    void Update()
    {
       if(Time.time > timeToShoot)
        {
            Shoot();
            timeToShoot = Time.time + 1 / fireRate;
        }
    }

    private void Shoot()
    {   
        Instantiate(bulletPrefab, enemyFirePoint.position, enemyFirePoint.rotation * Quaternion.Euler(0, 180, 0));
    }
}
