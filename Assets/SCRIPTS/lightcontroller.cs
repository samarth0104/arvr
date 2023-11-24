using UnityEngine;

public class LightSwitchController : MonoBehaviour
{
    public Light[] lights; // Array of lights controlled by the switch
    private bool isPlayerNear = false;
    private bool areLightsOn = false; // Flag to track if lights are on or off

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.L))
        {
            ToggleLights();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            isPlayerNear = true;
            Debug.Log("Player entered light switch trigger zone");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            isPlayerNear = false;
            Debug.Log("Player exited light switch trigger zone");
        }
    }

    void ToggleLights()
    {
        areLightsOn = !areLightsOn;
        foreach (Light light in lights)
        {
            light.enabled = areLightsOn;
        }
        Debug.Log("Lights toggled: " + (areLightsOn ? "on" : "off"));
    }
}
