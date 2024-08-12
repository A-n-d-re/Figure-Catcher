using UnityEngine;

public class BasketController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.2f;
    [SerializeField] private float maxSpeed = 0.2f;

    private Vector2 lastTouchPosition;
    private Vector2 velocity;
    private bool isSwiping;

    private Camera mainCamera;
    private float xMin, xMax;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        //сделал проверку границ камеры каждый кадр чисто для презентации, так как если сделать только в Start, то устанавливаются начальные границы камеры 16:9, так как эмулятор выключен
        UpdateCameraBounds();

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    lastTouchPosition = touch.position;
                    isSwiping = true;
                    break;

                case TouchPhase.Moved:
                    if (isSwiping)
                    {
                        Vector2 currentTouchPosition = touch.position;
                        Vector2 deltaPosition = currentTouchPosition - lastTouchPosition;

                        velocity = deltaPosition * moveSpeed * Time.fixedDeltaTime;
                        velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);

                        Vector3 newPosition = transform.position + new Vector3(velocity.x, 0, 0);

                        newPosition.x = Mathf.Clamp(newPosition.x, xMin, xMax);

                        transform.position = newPosition;
                        lastTouchPosition = currentTouchPosition;
                    }
                    break;

                case TouchPhase.Ended:
                    isSwiping = false;
                    velocity = Vector2.zero;
                    break;
            }
        }
        else
        {
            if (isSwiping)
            {
                velocity = Vector2.Lerp(velocity, Vector2.zero, Time.fixedDeltaTime * 5f);

                Vector3 newPosition = transform.position + new Vector3(velocity.x, 0, 0);
                newPosition.x = Mathf.Clamp(newPosition.x, xMin, xMax);

                transform.position = newPosition;
            }
        }
    }

    private void UpdateCameraBounds()
    {
        float xMinBound = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float xMaxBound = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        xMin = xMinBound;
        xMax = xMaxBound;
    }
}