using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fandisplay : MonoBehaviour
{
    public GameObject opentext;
    private bool isPlayerNear = false;
    // Start is called before the first frame update
    void Start()
    {
        opentext.SetActive(false);
    }

    // Update is called once per frame
    
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
