using UnityEngine;

public class RockMovement : MonoBehaviour
{
    public float speed = 100f;
    //public float lifeTime = 2f;

    void Start()
    {
        //Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
