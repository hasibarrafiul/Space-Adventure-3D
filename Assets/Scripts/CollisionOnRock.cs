using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionOnRock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            transform.position = new Vector3(Mathf.Round(Random.Range(-50, 50) / 5) * 5, 1, Random.Range(300, 1000));
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            transform.position = new Vector3(Mathf.Round(Random.Range(-50, 50) / 5) * 5, 1, Random.Range(300, 1000));
        }
    }
}
