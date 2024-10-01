using UnityEngine;

public class DemoMovement : MonoBehaviour
{
    public float moveDistance = 5f;  // Distance to move forward and backward
    public float moveSpeed = 2f;     // Speed of movement

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool movingForward = true;
    private float progress = 0f;

    void Start()
    {
        // Store the starting position
        startPosition = transform.position;
        // Set the target position to be the start plus the distance forward
        targetPosition = startPosition + transform.forward * moveDistance;
    }

    void Update()
    {
        // Lerp the object's position between start and target
        progress += Time.deltaTime * moveSpeed / moveDistance;

        if (movingForward)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, progress);
            // Rotate to face the forward movement direction
            transform.rotation = Quaternion.LookRotation(targetPosition - startPosition);
        }
        else
        {
            transform.position = Vector3.Lerp(targetPosition, startPosition, progress);
            // Rotate to face the backward movement direction
            transform.rotation = Quaternion.LookRotation(startPosition - targetPosition);
        }

        // Check if we've completed the move in either direction
        if (progress >= 1f)
        {
            // Reverse the movement direction and reset progress
            movingForward = !movingForward;
            progress = 0f;
        }
    }
}
