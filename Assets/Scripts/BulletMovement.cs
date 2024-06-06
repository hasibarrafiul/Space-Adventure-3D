using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 10000000000f;
    public float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime * 10);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            Destroy(gameObject);
        }
    }
}
