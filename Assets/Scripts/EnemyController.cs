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
        Destroy(other.gameObject);

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        GameManager.Instance.AddScore(10); // ✅ +10 points for each enemy

        Destroy(gameObject);
    }
    else if (other.CompareTag("Player"))
    {
        // Enemy hit the player → game over
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        GameManager.Instance.GameOver();
        Destroy(other.gameObject); // destroy player
        Destroy(gameObject); // destroy enemy
    }
}

}