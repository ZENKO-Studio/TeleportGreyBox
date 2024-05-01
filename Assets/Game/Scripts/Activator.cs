using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public Teleport teleportScript; // Reference to the Teleport script

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player enters the trigger zone
        {
            teleportScript.ActivateTeleport(true); // Activate the portal when the player enters
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player exits the trigger zone
        {
            teleportScript.ActivateTeleport(false); // Deactivate the portal when the player exits
        }
    }
}
