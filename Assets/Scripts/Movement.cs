using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                // Get the touch position in the world space
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, (-Camera.main.transform.position.z)));
                
                // Calculate the new position
                Vector3 newPosition = new Vector3(touchPosition.x, transform.position.y, transform.position.z);

                // Smoothly move the player to the touch position
                transform.position = Vector3.Lerp(transform.position, newPosition, moveSpeed * Time.deltaTime);
            }
        }
    }
}
