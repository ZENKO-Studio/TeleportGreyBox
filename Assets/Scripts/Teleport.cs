using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform player;
    public Transform[] destination; // Array of possible teleport destinations
    public GameObject playerg;      // Player game object
    private bool teleportActive = false; // Teleport activation flag

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the trigger is the teleport activator
        {
            teleportActive = true; // Activate teleportation
        }

        if (teleportActive && other.CompareTag("Player")) // Check if teleport is active and the collider is the player
        {
            int destinationIndex = Random.Range(0, destination.Length); // Randomize destination index
            playerg.SetActive(false);   // Disable player object temporarily
            player.position = destination[destinationIndex].position; // Set player position to random destination
            playerg.SetActive(true);    // Re-enable player object
            teleportActive = false; // Reset teleport activation (if one-time use per activation)
        }
    }
}
