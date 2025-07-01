/*
	Christopher Isidro
	2370110
	cisidro@chapman.edu
	CPSC-340-01
	Roommate Rescue

	Function: Handles raycasting from the player.  Receives object that the raycast intersects with and sends it to the item display text script.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera playerCamera; //reference to player camera to get dimensions and display other UI 
    public ItemDisplayText display; //reference to text in UI 
    public PickupLogic pickupLogic; //reference to pickupLogic to potentially clone 
    public KeypadDisplay keypadDisplay;
	private GameObject hitObject; //see which object gets hit 
    void Start()
    {
        
    }
    
    private void HandleRaycast() //Raycast at a minimum distance of 2 and see waht it intersects with 
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0); 
        Ray ray = playerCamera.ScreenPointToRay(screenCenter); 
        RaycastHit hitInfo;
        float maxDistance = 2.5f;
	
        if(Physics.Raycast(ray, out hitInfo, maxDistance))
        {
            hitObject = hitInfo.collider.gameObject;
            if (hitObject.CompareTag("PickupAble") || hitObject.CompareTag("Scrap"))
            {
                display.changeText("INSPECT (E)");
            }
            //Debug.Log("Raycast hit: " + hitObject.name);
            else if (hitObject.CompareTag("MoveableObject"))
            {
                display.changeText("PICK UP (E)");
            }
            else if (hitObject.CompareTag("Keypad"))
            {
                display.changeText("INSPECT (E)");
                keypadDisplay.canInput = true;
            }
            else
            {
                display.changeText("");
                keypadDisplay.canInput = false;
            }
            //display.changeText(hitObject.name);
        }

        else
        {
            display.changeText("");
        }
        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.red);
    }

	public GameObject getHitObject() //function to be called by clone object 
	{
		return hitObject;
	}

    // Update is called once per frame
    void Update()
    {
        HandleRaycast();
    }
    
    
}
