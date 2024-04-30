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
             // Call the method to activate the portal
        }
    }
}
