using UnityEngine;
using System.Collections;

public class ScriptBicho : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 8f;
    public float fireRate = 2f; // cada cuantos segundos dispara
    public Transform bulletsParent;
    void Start()
    {
        StartCoroutine(ShootRandom());
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation, bulletsParent);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.left * bulletSpeed;
    }
    IEnumerator ShootRandom()
    {
        while (true)
        {
            float randomTime = Random.Range(0.5f, 2f); // dispara entre 0.5 y 2 segundos
            yield return new WaitForSeconds(randomTime);

            Shoot();
        }
    }

}
