using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    private bool isPlayerInside = false; // Flag to track if player is inside the collider
    private bool isRotating = false; // Flag to track if cube is rotating
    private int rotationDirection = 1; // Variable to control rotation direction (+1 or -1)
    private float rotationSpeed = 90f; // Speed of rotation

    void Update()
    {
        if (isPlayerInside && Input.GetKeyDown(KeyCode.F) && !isRotating)
        {
            ToggleRotation();
        }

        if (isRotating)
        {
            RotateCube();
        }
    }

    void ToggleRotation()
    {
        isRotating = true;
        rotationDirection *= -1; // Change rotation direction
    }

    void RotateCube()
    {
        float step = rotationSpeed * Time.deltaTime * rotationDirection; // Adjust speed and direction
        transform.Rotate(Vector3.right, step);

        // Check if reached the desired angle, then stop rotating
        if (Mathf.Abs(transform.rotation.eulerAngles.x) >= 20f)
        {
            transform.rotation = Quaternion.Euler(20f * rotationDirection, 0f, 0f);
            isRotating = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            isPlayerInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            isPlayerInside = false;
        }
    }
}
