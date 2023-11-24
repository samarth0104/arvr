using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public GameObject opentext;
    public Transform doorHinge; // Reference to the hinge side of the door
    public float openAngle = 90f; // Angle by which the door should open
    public float rotationSpeed = 50f; // Speed at which the door rotates
     // Reference to the UIManager script
    private bool isPlayerNear = false;
    private bool isDoorOpen = false; // Flag to track if the door is open or closed

    private void Start()
    {
        opentext.SetActive(false);

    }
    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.T))
        {
            ToggleDoor();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            isPlayerNear = true;
            
            opentext.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            isPlayerNear = false;
           
            opentext.SetActive(false);
        }
    }

    void ToggleDoor()
    {
        isDoorOpen = !isDoorOpen;
        float targetAngle = isDoorOpen ? openAngle : 0f;
        StartCoroutine(RotateDoor(targetAngle));
    }

    IEnumerator RotateDoor(float targetAngle)
    {
        float startAngle = doorHinge.localRotation.eulerAngles.y;
        float currentAngle = startAngle;
        float timer = 0f;

        while (currentAngle != targetAngle)
        {
            timer += Time.deltaTime * rotationSpeed;
            currentAngle = Mathf.Lerp(startAngle, targetAngle, timer);
            doorHinge.localRotation = Quaternion.Euler(0f, currentAngle, 0f);
            yield return null;
        }

        Debug.Log("Door " + (isDoorOpen ? "opened" : "closed"));
    }
}