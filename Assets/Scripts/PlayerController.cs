using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private float targetX;

    void Start()
    {
        targetX = transform.position.x;
    }

    void Update()
    {
        // --- Get Input ---
        float moveInput = Input.GetAxis("Horizontal");
        targetX += moveInput * moveSpeed * Time.deltaTime;

        // --- Smooth Movement ---
        Vector3 currentPos = transform.position;
        currentPos.x = Mathf.Lerp(currentPos.x, targetX, 0.15f); // 0.15 = smoothness factor
        transform.position = currentPos;

        // --- Shooting ---
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }
    }
}
