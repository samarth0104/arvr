using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    private GameObject player;
    private GameObject currentlyHeldObject;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            currentlyHeldObject = gameObject;
            Debug.Log("entered the zone");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            currentlyHeldObject = null;
            Debug.Log("exit the zone");
        }
    }

    void Update()
    {
        if (currentlyHeldObject != null && Input.GetKeyDown(KeyCode.E))
        {
            PickOrDropObject();
        }
    }

    void PickOrDropObject()
    {
        if (currentlyHeldObject.transform.parent == player.transform)
        {
            currentlyHeldObject.transform.SetParent(null);
        }
        else
        {
            currentlyHeldObject.transform.SetParent(player.transform);
            currentlyHeldObject.transform.localPosition = new Vector3(0, 0, 2); // Adjust position
        }
    }
}
