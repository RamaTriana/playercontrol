using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 100f;
    public float verticalInput;
    public float speedIncrement = 2f;  // Kecepatan perubahan
    public float minSpeed = 5f;  // Kecepatan minimum
    public float maxSpeed = 20f; // Kecepatan maksimum

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // Adjust the speed based on player input
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            speed += speedIncrement * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            speed -= speedIncrement * Time.deltaTime;
        }

        // Clamp the speed to the min and max values
        speed = Mathf.Clamp(speed, minSpeed, maxSpeed);

        // Move the plane forward at the current speed
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Tilt the plane up/down based on up/down arrow keys
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.right * verticalInput * rotationSpeed * Time.deltaTime);
        }
    }
}
