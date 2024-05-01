using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnTeleManager : MonoBehaviour
{
    public Transform player;
    public GameObject playerGameObject; // Player game object
    public bool isActive = true; // Teleport activation control

    // Teleport the player to a teleport with a specific tag
    public void TeleportToTaggedPortal(string tag)
    {
        Teleport[] teleports = FindObjectsOfType<Teleport>();
        foreach (var teleport in teleports)
        {
            if (teleport.tag == tag)
            {
                player.transform.position = teleport.transform.position;
                playerGameObject.SetActive(false); // Disable player object temporarily
                playerGameObject.SetActive(true); // Re-enable player object
                return;
            }
        }
        Debug.Log("No teleport found with tag: " + tag);
    }
}
