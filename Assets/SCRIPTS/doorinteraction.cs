using UnityEngine;
using UnityEngine.UI;

public class DoorInteraction : MonoBehaviour
{
    private Text interactText; // Reference to the UI Text element
    private bool isPlayerNear = false;

    void Start()
    {
        // Find the UI Text component automatically
        interactText = GameObject.Find("door text").GetComponent<Text>();
        if (interactText == null)
        {
            Debug.LogError("UI Text not found. Make sure it's a child of the Canvas.");
        }
        else
        {
            interactText.enabled = false; // Hide text initially
        }
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera")) // Replace "Player" with your player's tag
        {
            isPlayerNear = true;
            interactText.enabled = true;
            interactText.text = "Press 'T' to open the door";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera")) // Replace "Player" with your player's tag
        {
            isPlayerNear = false;
            interactText.enabled = false;
        }
    }
}
