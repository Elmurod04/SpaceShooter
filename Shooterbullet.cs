using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bulletPrefab != null && firePoint != null)
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.linearVelocity = firePoint.up * bulletSpeed;

                Destroy(bullet, 2f); // 2 sekunddan keyin o‘chadi
            }
            else
            {
                Debug.LogWarning("Bullet prefab yoki firePoint yo‘q!");
            }
        }
    }
}
