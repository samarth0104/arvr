using UnityEngine;

public class FanController : MonoBehaviour
{
    public float rotationSpeed = 200f; // Speed at which the fan rotates
    private bool isPlayerNear = false;
    private bool isFanOn = false; // Flag to track if the fan is on or off

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.F))
        {
            isFanOn = !isFanOn;
            Debug.Log("F key pressed, isFanOn: " + isFanOn); // Add this log
        }

        if (isFanOn)
        {
            RotateFan();
            Debug.Log("Rotating the fan"); // Add this log
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            isPlayerNear = true;
            Debug.Log("Player entered fan trigger zone");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            isPlayerNear = false;
            Debug.Log("Player exited fan trigger zone");
        }
    }

    void RotateFan()
    {
        // Rotate the fan around its Y-axis based on the rotationSpeed
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
