using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public Vector3 minPosition = new Vector3(-10, -10, -10);
    public Vector3 maxPosition = new Vector3(10, 10, 10);
    public float minScale = 0.5f;
    public float maxScale = 2.0f;
    public float minRotationSpeed = 5.0f;
    public float maxRotationSpeed = 20.0f;
    public float rotationSpeedMultiplier = 0.1f; // Control the overall rotation speed

    private Vector3 rotationAngle;
    private float rotationSpeed;
    private Color targetColor;

    void Start()
    {
        // Change the cube's location randomly
        transform.position = new Vector3(
            Random.Range(minPosition.x, maxPosition.x),
            Random.Range(minPosition.y, maxPosition.y),
            Random.Range(minPosition.z, maxPosition.z)
        );

        // Change the cube's scale randomly
        transform.localScale = Vector3.one * Random.Range(minScale, maxScale);

        // Change the angle at which the cube rotates randomly
        rotationAngle = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));

        // Change the cube’s rotation speed randomly
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);

        Material material = Renderer.material;

        // Change the cube’s material color randomly
        material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0.2f, 1f));

        // Initialize target color for color change over time
        targetColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0.2f, 1f));
    }

    void Update()
    {
        // Rotate the cube based on the random speed and angles, controlled by the multiplier
        transform.Rotate(rotationAngle * rotationSpeed * rotationSpeedMultiplier * Time.deltaTime);

        // Smoothly change the color of the cube over time
        Material material = Renderer.material;
        material.color = Color.Lerp(material.color, targetColor, Time.deltaTime);

        // Change the target color randomly every few seconds
        if (Vector4.Distance(material.color, targetColor) < 0.1f)
        {
            targetColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0.2f, 1f));
        }
    }
}