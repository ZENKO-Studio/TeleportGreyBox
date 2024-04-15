using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleMove : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the capsule

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Get horizontal input (A/D, Left/Right Arrow)
        float moveVertical = Input.GetAxis("Vertical"); // Get vertical input (W/S, Up/Down Arrow)

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); // Create movement vector
        transform.Translate(movement * speed * Time.deltaTime, Space.World); // Move the capsule
    }
}
