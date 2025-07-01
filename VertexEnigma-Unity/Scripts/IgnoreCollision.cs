/*
	Christopher Isidro
	2370110
	cisidro@chapman.edu
	CPSC-340-01
	Roommate Rescue

	Function: Attempt to fix problem where cloned objects will move player.  This script is a try at ignoring a layer defined as PickObject
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    public Collider colliderToIgnore;
    public string layerToIgnore = "PickObject"; //defined layer to ignore 
    void Start()
    {
        int layerToIgnoreID = LayerMask.NameToLayer(layerToIgnore);

        if (colliderToIgnore != null && layerToIgnoreID != -1)
        {
            Collider[] colliders = GetComponents<Collider>();
            foreach (Collider collider in colliders)
            {
                Physics.IgnoreCollision(collider, colliderToIgnore);
            }
        }
    }

}
