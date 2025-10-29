using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 8f;

    void Update()
    {
        // O‘q yuqoriga harakatlanadi
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // Agar o‘q ekrandan chiqib ketsa, yo‘q qilinadi
        if (transform.position.y > 6f)
        {
            Destroy(gameObject);
        }
    }
}
