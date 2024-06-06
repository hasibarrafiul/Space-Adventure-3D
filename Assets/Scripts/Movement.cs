using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject RockPrefab1;
    public GameObject RockPrefab2;
    public GameObject RockPrefab3;
    public float moveSpeed = 25f;
    private Vector2 touchStartPos;
    private bool isSwiping = false;
    private float swipeThreshold = 25f;
    private bool isTouching = false;
    private Vector2 lastTouchPosition;
    private Coroutine shootingCoroutine;

    public int upperBound = 50;
    public int lowerBound = -50;

    public int spawnCount = 5;

    private void Start() {
        for (int i = 0; i < spawnCount; i++)
        {
            // Generate a random position within the specified range
            Vector3 randomPosition = new Vector3(
                Mathf.Round(Random.Range(-50, 50) / 5) * 5, 1, Random.Range(300, 1000)
            );

            // Instantiate a new object at the random position
            Instantiate(RockPrefab1, randomPosition, Quaternion.identity);
        }

        for (int i = 0; i < spawnCount; i++)
        {
            // Generate a random position within the specified range
            Vector3 randomPosition = new Vector3(
                Mathf.Round(Random.Range(-50, 50) / 5) * 5, 1, Random.Range(300, 1000)
            );

            // Instantiate a new object at the random position
            Instantiate(RockPrefab2, randomPosition, Quaternion.identity);
        }

        for (int i = 0; i < spawnCount; i++)
        {
            // Generate a random position within the specified range
            Vector3 randomPosition = new Vector3(
                Mathf.Round(Random.Range(-50, 50) / 5) * 5, 1, Random.Range(300, 1000)
            );

            // Instantiate a new object at the random position
            Instantiate(RockPrefab3, randomPosition, Quaternion.identity);
        }
    }

    private void Update()
    {
        HandleTouchInput();
        MoveCharacter();
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            lastTouchPosition = touch.position;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    isTouching = true;
                    isSwiping = false;
                    StartShooting();
                    break;

                case TouchPhase.Moved:
                    Vector2 touchDelta = touch.position - touchStartPos;
                    if (Mathf.Abs(touchDelta.x) > Mathf.Abs(touchDelta.y) && Mathf.Abs(touchDelta.x) > swipeThreshold)
                    {
                        isSwiping = true;
                    }
                    break;

                case TouchPhase.Stationary:
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    isTouching = false;
                    isSwiping = false;
                    StopShooting();
                    break;
            }
        }
        else
        {
            isTouching = false;
            isSwiping = false;
            StopShooting();
        }
    }

    private void MoveCharacter()
    {
        if (isTouching && isSwiping)
        {
            Vector2 touchDelta = lastTouchPosition - touchStartPos;
            if ((touchDelta.x > swipeThreshold) && transform.position.x < upperBound)
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
            else if ((touchDelta.x < -swipeThreshold) && transform.position.x > lowerBound)
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
        }
    }

    private void StartShooting()
    {
        if (shootingCoroutine == null)
        {
            shootingCoroutine = StartCoroutine(ShootContinuously(0.2f));
        }
    }

    private void StopShooting()
    {
        if (shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
        }
    }

    private IEnumerator ShootContinuously(float interval)
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(interval);
        }
    }

    private void Shoot()
    {
        Vector3 currentPosition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        Quaternion newRotation = Quaternion.Euler(0, 90, 90);

        Instantiate(bulletPrefab, currentPosition, newRotation);
    }
}
