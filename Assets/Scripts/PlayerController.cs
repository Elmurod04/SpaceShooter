using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    private Vector2 movement;
    private Camera cam;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.25f;
    private float nextFireTime = 0f;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    // -------------------------------
    // MOVEMENT (PC + Mobile Touch)
    // -------------------------------
    void HandleMovement()
    {
        movement = Vector2.zero;

        // PC controls
        float horizontal = Input.GetAxis("Horizontal");
        float vertical   = Input.GetAxis("Vertical");
        movement = new Vector2(horizontal, vertical);

        // Mobile touch
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            Vector3 touchPos = cam.ScreenToWorldPoint(t.position);
            touchPos.z = 0;

            // Move smoothly toward touch
            transform.position = Vector3.Lerp(
                transform.position,
                touchPos,
                Time.deltaTime * 5f
            );
            return;
        }

        // Apply movement (PC)
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    // -------------------------------
    // SHOOTING
    // -------------------------------
    void HandleShooting()
    {
        if (Time.timeScale == 0f) return; // can't shoot on pause

        bool shootPressed = Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0);

        if (shootPressed && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    // -------------------------------
    // COLLISION WITH ENEMY
    // -------------------------------
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameManager.Instance.GameOver();

            // Destroy spaceship AFTER UI appears
            Destroy(gameObject, 0.05f);
        }
    }
}
