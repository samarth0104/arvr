using UnityEngine;
using UnityEngine.UI;

public class BookInteraction : MonoBehaviour
{
    public GameObject opentext;
    private bool isPlayerNear = false;
    private void Start()
    {
        opentext.SetActive(false);

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
}
