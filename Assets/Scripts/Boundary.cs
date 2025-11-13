using UnityEngine;

public class Boundary : MonoBehaviour
{
    public float xMin = -2.5f;
    public float xMax = 2.5f;
    public float yMin = -4f;
    public float yMax = 4f;

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, xMin, xMax);
        pos.y = Mathf.Clamp(pos.y, yMin, yMax);
        transform.position = pos;
    }
}
