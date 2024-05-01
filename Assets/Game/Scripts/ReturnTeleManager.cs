using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnTeleManager : MonoBehaviour
{
    public Teleport teleport; // Reference to the Teleport script
    private Vector3 originalPosition; // To store the original position
    private bool hasTeleported = false; // To check if the player has teleported

    // Start is called before the first frame update
    void Start()
    {
        if (teleport != null)
        {
            // Subscribe to the event
            teleport.OnTeleport += HandleTeleport;
        }
    }

    private void HandleTeleport(Vector3 newPosition)
    {
        if (!hasTeleported)
        {
            originalPosition = newPosition; // Store the position from which the player teleported
            hasTeleported = true;
        }
    }

    // Method to teleport the player back to the original position
    public void TeleportToOriginal()
    {
        if (hasTeleported)
        {
            teleport.player.transform.position = originalPosition;
            hasTeleported = false; // Reset the teleportation flag
        }
    }

    private void OnDestroy()
    {
        if (teleport != null)
        {
            // Unsubscribe to prevent memory leaks
            teleport.OnTeleport -= HandleTeleport;
        }
    }
}
