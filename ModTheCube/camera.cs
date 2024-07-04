using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform player; // The player's transform
    public Vector3 offset; // Offset between the camera and the player
    public float smoothSpeed = 0.125f; // Speed of the camera's smoothing

    void Start()
    {
        // Initialize the offset based on initial positions
        if (player != null)
        {
            offset = transform.position - player.position;
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Target position based on player position and offset
            Vector3 desiredPosition = player.position + offset;
            // Smoothly move the camera towards the target position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // Optional: make the camera look at the player
            transform.LookAt(player);
        }
    }
}