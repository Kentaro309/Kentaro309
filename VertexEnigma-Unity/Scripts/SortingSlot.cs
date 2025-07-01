using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingSlot : MonoBehaviour
{
    public GameObject correctObject; // Assign the correct object in the Unity Inspector
    public bool isCorrectObjectFullyInside; // This boolean tracks the object's presence
    public static event Action<SortingSlot, bool> OnSlotStateChanged; //Notifies when the slot state is changed.
    public GameObject snapPos;

    void Start()
    {
        isCorrectObjectFullyInside = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("SortObject"))
        {
            SnapObjectToSlot(other.gameObject);
        }

        if (other.gameObject == correctObject)
        {
            isCorrectObjectFullyInside = true;
            Debug.Log("Correct object has entered the slot.");
            OnSlotStateChanged?.Invoke(this, isCorrectObjectFullyInside);
            // Additional actions here (e.g., disable movement, snap to position)
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == correctObject)
        {
            // Object has left the slot
            isCorrectObjectFullyInside = false;
            Debug.Log("Correct object has exited the slot.");
            OnSlotStateChanged?.Invoke(this, isCorrectObjectFullyInside);
            // Additional actions here if necessary
        }
    }

    // Optionally, if need continuous verification or more complex conditions:
    private void OnTriggerStay(Collider other)
    {
        // Use this to continuously check for conditions 
        // while the object is within the trigger area.
    }

    void SnapObjectToSlot(GameObject objectToSnap)
    {
        // Calculate the bottom of the object to snap
        float objectBottom = objectToSnap.GetComponent<Collider>().bounds.min.y;
        float objectHeight = objectToSnap.GetComponent<Collider>().bounds.size.y;
        Rigidbody objectRigidbody = objectToSnap.GetComponent<Rigidbody>();

        // Calculate the top of the slot
        float slotTop = snapPos.transform.position.y;

        // Calculate the position to move the object so its bottom aligns with the top of the slot
        Vector3 newPosition = snapPos.transform.position + new Vector3(0, slotTop - objectBottom + objectHeight / 2, 0);

        // Apply the new position to the object
        objectToSnap.transform.position = newPosition;
        objectRigidbody.velocity = Vector3.zero;
        objectRigidbody.angularVelocity = Vector3.zero;
        objectRigidbody.rotation = Quaternion.identity;
    }
}
