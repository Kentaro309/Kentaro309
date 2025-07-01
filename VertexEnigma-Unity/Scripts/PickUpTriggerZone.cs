/*
	Christopher Isidro
	2370110
	cisidro@chapman.edu
	CPSC-340-01
	Roommate Rescue

	Function: NO LONGER IN USE - Script was used as a workaround to the object raytrace cloning.  Box colliders were used with invisible objects held in 
	player UI and was revealed if the interact button was pressed and if the player was inside the collider.  Keeping this as a test for future works.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTriggerZone : MonoBehaviour
{
    public bool canPickUp = false;
    public GameObject itemPickUp;
    public Renderer gameItem;
    public KeyCode interactButton = KeyCode.E;
    public FirstPersonController fpc;
    public RotateController rotateController;

    private void Update() //checks pickup boolean and input
    {
        if (Input.GetKeyDown(interactButton) && canPickUp)
        {
            ShowItem();
            Debug.Log("Show");
        }
        else if(!canPickUp)
        {
            //HideItem();
        }
    }
    void OnTriggerEnter(Collider other) //checks trigger entry for picking up object (old)
    {
        Debug.Log("Entered");
        canPickUp = true;
    }

    void OnTriggerExit(Collider other) //checks trigger exit for pickup (old) 
    {
        Debug.Log("Exited");
        canPickUp = false;
        rotateController.SetRotatingFalse();
		HideItem();
    }
    
    
    public void ShowItem() //enabled object in player UI and hid game object (old) 
    {
        itemPickUp.SetActive(true);
        gameItem.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //fpc.playerCanMove = true;
        fpc.cameraCanMove = false;
    }

    public void HideItem() //disabled object in UI and enabled game object (old) 
    {
        itemPickUp.SetActive(false);
        gameItem.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fpc.playerCanMove = true;
        fpc.cameraCanMove = true;
    }
}
