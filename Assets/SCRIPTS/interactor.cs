using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactor : MonoBehaviour
{
    public LayerMask interactablelayermask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit, 2, interactablelayermask))
        {
            Debug.Log(hit.collider.name);
        }
    }
}
