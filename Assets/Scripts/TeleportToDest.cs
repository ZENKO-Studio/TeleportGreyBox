using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToDest : MonoBehaviour
{
    public Transform player;
    public Transform[] destinations; // Array of possible teleport destinations
    public GameObject playerg;       // Player game object
    public int destinationIndex = 0; // Default index of the destination, settable in the editor

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerg.SetActive(false); // Disable player object temporarily
            player.position = destinations[destinationIndex].position; // Set player position to the specified destination
            playerg.SetActive(true);  // Re-enable player object
        }
    }
}
