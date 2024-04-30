using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform player;
    public Transform[] destinations; // Array of possible teleport destinations
    public GameObject playerGameObject; // Player game object


    private void OnTriggerEnter(Collider other)
    {
         // Check if teleport is active and the collider is the player
        
            int destinationIndex = Random.Range(0, destinations.Length); // Randomize destination index
            playerGameObject.SetActive(false);   // Disable player object temporarily
            player.transform.position = destinations[destinationIndex].transform.position; // Set player position to random destination
            playerGameObject.SetActive(true);    // Re-enable player object
            // Reset teleport activation (if one-time use per activation)
       
    }
}
