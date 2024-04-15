using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform player;
    public Transform[] destination; // Array of possible teleport destinations
    public GameObject playerg;      // Player game object

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int destinationIndex = Random.Range(0, destination.Length); // Randomize destination index
            playerg.SetActive(false);   // Disable player object temporarily
            player.position = destination[destinationIndex].position; // Set player position to random destination
            playerg.SetActive(true);    // Re-enable player object
        }
    }
}
