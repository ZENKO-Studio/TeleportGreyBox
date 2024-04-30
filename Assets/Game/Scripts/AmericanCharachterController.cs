using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmericanCharachterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator; // Drag your Animator component here in the inspector

    void Update()
    {
        // Input from WASD keys
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Movement vector
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // Move the character
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // Animating the character
        if (moveDirection != Vector3.zero)
        {
            // Get the magnitude of the input.
            float inputMagnitude = moveDirection.magnitude;
            // Set the Speed parameter in the animator to control the blend tree
            animator.SetFloat("Speed", inputMagnitude * moveSpeed);

            // Rotate the character to the direction of movement
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, moveSpeed * 100 * Time.deltaTime);
        }
        else
        {
            // If there is no input, the speed is zero.
            animator.SetFloat("Speed", 0);
        }
    }
}
