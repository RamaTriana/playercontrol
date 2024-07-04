using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Called when a collision occurs
    void OnCollisionEnter(Collision collision)
    {
        // Check if colliding with dogPrefab
        if (collision.gameObject.CompareTag("Dog"))
        {
            // Destroy the ball
            Destroy(gameObject);
        }
    }
}
