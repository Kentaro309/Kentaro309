using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingManager : MonoBehaviour
{
    // Make the list public or use [SerializeField] to keep it private but visible in the editor
    public List<SortingSlot> slots = new List<SortingSlot>();

    void Awake()
    {
        SortingSlot.OnSlotStateChanged += CheckAllSlots;
    }

    void OnDestroy()
    {
        SortingSlot.OnSlotStateChanged -= CheckAllSlots;
    }

    private void CheckAllSlots(SortingSlot slot, bool state)
    {
        foreach (var s in slots)
        {
            if (!s.isCorrectObjectFullyInside) return; // Assuming you've implemented IsCorrectObjectFullyInside as a property
        }
        
        Debug.Log("SORTING COMPLETED \n\n\n\n");
        // Actions to perform when all slots are correctly filled
    }
}
