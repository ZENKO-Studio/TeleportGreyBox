
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform player;
    public Transform[] destinations;
    public GameObject playerGameObject;
    public bool isActive = true;

    public event Action<Vector3> OnTeleport; // Event to notify when teleportation occurs

    private void OnTriggerEnter(Collider other)
    {
        if (isActive && other.CompareTag("Player"))
        {
            int destinationIndex = UnityEngine.Random.Range(0, destinations.Length);
            playerGameObject.SetActive(false);
            Vector3 newPosition = destinations[destinationIndex].transform.position;
            player.transform.position = newPosition;
            playerGameObject.SetActive(true);
            isActive = false;

            OnTeleport?.Invoke(newPosition); // Invoke the teleport event
        }
    }

    public void ActivateTeleport(bool state)
    {
        isActive = state;
    }
}