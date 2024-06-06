using UnityEngine;

public class RockMovement : MonoBehaviour
{
    public float speed = 100f;
    public float increaseAmount = 0.5f;

    void Update()
    {
        speed += increaseAmount * Time.deltaTime;
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (transform.position.z < -10)
        {
            transform.position = new Vector3(Mathf.Round(Random.Range(-50, 50) / 5) * 5, 1, Random.Range(300, 1000));
        }
    }
}
