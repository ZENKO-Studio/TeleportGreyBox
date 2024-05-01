
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform player;
    public Transform[] destinations; // Array of possible teleport destinations
    public GameObject playerGameObject; // Player game object
    public bool isActive = true; // Teleport activation control

    private void OnTriggerEnter(Collider other)
    {
        if (isActive && other.CompareTag("Player")) // Check if teleport is active and the collider is the player
        {
            int destinationIndex = Random.Range(0, destinations.Length); // Randomize destination index
            playerGameObject.SetActive(false);   // Disable player object temporarily
            player.transform.position = destinations[destinationIndex].transform.position; // Set player position to random destination
            playerGameObject.SetActive(true);    // Re-enable player object
            isActive = false; // Optionally disable after use, if one-time use is needed
        }
    }

    // Method to activate the teleport
    public void ActivateTeleport(bool state)
    {
        isActive = state;
    }
}