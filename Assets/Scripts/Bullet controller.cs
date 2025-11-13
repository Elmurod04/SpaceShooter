using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (transform.position.y > 6f)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // If bullet hits enemy
        if (other.CompareTag("Enemy"))
        {
            
            Destroy(other.gameObject); // destroy enemy
            Destroy(gameObject); // destroy bullet
        }
    }
}
