using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    private ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        if (ps == null)
        {
            ps = GetComponentInChildren<ParticleSystem>();
        }
    }

    void Update()
    {
        if (ps && !ps.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}
