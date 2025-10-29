using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;
    public GameObject explosionPrefab;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // o‘qni yo‘qot

            // 💥 Portlash yaratamiz
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Destroy(gameObject); // dushmanni yo‘qot
        }
    }
}
