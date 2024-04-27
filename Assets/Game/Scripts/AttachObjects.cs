using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachObjects : MonoBehaviour
{
    public Transform objectToAttach; // Assign this in the Inspector
    public Transform targetParent;   // Assign this in the Inspector

    void Start()
    {
        // Attach the object as a child of the target parent
        objectToAttach.SetParent(targetParent, false);

      
    }
}
