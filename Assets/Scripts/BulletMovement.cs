using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 10000000000f;
    public float lifeTime = 2f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime * 10);
    }
}
