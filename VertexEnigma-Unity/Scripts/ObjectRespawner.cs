using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRespawner : MonoBehaviour
{
    public GameObject respawnPoint;  // Assign this in the inspector with your respawn GameObject

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = respawnPoint.transform.position;  // Move the object to the respawn point
        // reset velocity if the object uses Rigidbody
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
