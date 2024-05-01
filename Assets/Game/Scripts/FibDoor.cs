using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FibDoor : MonoBehaviour
{
    private int lastFib = 1;  // Last Fibonacci number
    private int secondLastFib = 0;  // Second last Fibonacci number
    private List<int> visitedDoors = new List<int>();  // List to keep track of visited door indices
    public Transform[] doors;  // Array of door transforms where the player can teleport to
    public Transform player;  // Player transform

    private void Start()
    {
        // Initial setup if needed
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Make sure the collider is tagged as "Door"
        {
            TeleportToRandomDoor();
        }
    }

    private void TeleportToRandomDoor()
    {
        if (doors.Length == 0)
            return;

        int nextFib = lastFib + secondLastFib;
        int doorIndex = nextFib % doors.Length;  // Calculate which door to teleport to

        Debug.Log("Teleport to Door: " + (doorIndex + 1));
        player.transform.position = doors[doorIndex].position;  // Teleport player to the door's position
        visitedDoors.Add(doorIndex);  // Save this door index

        // Update Fibonacci numbers
        secondLastFib = lastFib;
        lastFib = nextFib;
    }

    public void TeleportBack()
    {
        if (visitedDoors.Count <= 1)
            return;  // Cannot teleport back if there's only one or zero visits

        visitedDoors.RemoveAt(visitedDoors.Count - 1);  // Remove last visit
        int doorIndex = visitedDoors[visitedDoors.Count - 1];  // Get the last valid door index

        Debug.Log("Teleport back to Door: " + (doorIndex + 1));
        transform.position = doors[doorIndex].position;  // Teleport player back to the door's position
    }
}
