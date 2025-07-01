/*
	Christopher Isidro
	2370110
	cisidro@chapman.edu
	CPSC-340-01
	Roommate Rescue

	Function: Handles logic for checking if an object can be picked up through booleans of being able to be picked up.  This Script used to handle the appearance of ceratin objects
	but was changed later to raytrace cloning
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PickupLogic : MonoBehaviour
{
    public bool canPickUp = false;
    //public GameObject itemPickUp;
    //public Renderer gameItem;
    public KeyCode interactButton = KeyCode.E; //defined interact button 
    public FirstPersonController fpc; //reference to fpc to change player movement restraints 
	public ObjectCloning obCloning; //reference to object cloning script to call on object clone
    public RotateController rotateController; //reference to rotate controller to change boolean of object rotation 
	public RayCast raycast; //raycast reference to see what object player is looking at 
	public GameObject remote; //object reference to game object to enable/disable TV (not pickup) (should be new script) 
    public string objectName; //string to see what the object's name is to clone 
    private string uiObject; //NOT IN USE 
    private bool showing; //NOT IN USE 
	private GameObject objectClone; //cloned object reference in game 
    private bool isHoldingObject; //check if player is holding an object
    private GameObject objectInHand; //reference to object in player's hand
    private void Awake()
    {
        objectName = gameObject.name;
		//objectClone = fpc.getHitObject();
        isHoldingObject = false;
    }
    private void Update()
    {
        //Debug.Log("Object: " + objectName);
        //Debug.Log("UI: " + uiObject);
        //itemPickUp = GameObject.Find(uiObject);
        if (Input.GetKeyDown(interactButton) && !showing && !isHoldingObject) //(Input.GetKeyDown(interactButton) && uiObject == objectName && !showing)
        {
            ShowItem();
        }
        else if (Input.GetKeyDown(interactButton) && showing) //Input.GetKeyDown(interactButton) && uiObject == objectName && showing
        {
            HideItem();
            showing = false;
            rotateController.SetRotatingFalse();
        }
        else if (Input.GetKeyDown(interactButton) && isHoldingObject)
        {
            DropItem();
            isHoldingObject = false;
        }

		detectObject(); //Changed to a simpler raycast method to make things more modular
        //objectClone = raycast.getHitObject();
		//Debug.Log(objectClone.name);
    }
    
    public void detectObject() //Casts ray and detects object
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        float maxDistance = 2.5f; //max detect distance (change as needed)
        bool isHit = Physics.Raycast(ray, out hit, maxDistance);
        if (isHit && !showing && !isHoldingObject)
        {
            if (objectClone != null)
            {
                objectClone.GetComponent<Renderer>().material.SetColor("_EmissiveColor", Color.black); // reset color
                objectClone.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            }
            objectClone = hit.collider.gameObject; //set new object detected

            if (objectClone.CompareTag("PickupAble") || objectClone.CompareTag("MoveableObject"))
            {
                objectClone.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                objectClone.GetComponent<Renderer>().material.SetColor("_EmissiveColor", Color.white * 0.03f); // Increase intensity
            }
        }
        else
        {
            if (objectClone != null)
            {
                objectClone.GetComponent<Renderer>().material.SetColor("_EmissiveColor", Color.black); // reset color
                objectClone.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            }
            objectClone = null;
        }
    }
    
    public void ShowItem() // clones object and locks player movement 
    {
		if (objectClone.CompareTag("PickupAble") || objectClone.CompareTag("Scrap"))
		{
        	//itemPickUp.SetActive(true);
        	//gameItem.enabled = false;
            showing = true;
       	 	Cursor.lockState = CursorLockMode.None;
       	 	Cursor.visible = true;
        	fpc.setMoveBoolFalse();
        	fpc.cameraCanMove = false;
			obCloning.CloneObject(objectClone);
		}

        else if (objectClone.CompareTag("MoveableObject"))
        {
            objectInHand = objectClone;
            Rigidbody rb = objectInHand.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true; // Disable physics interactions
            }
            BoxCollider boxCollider = objectInHand.GetComponent<BoxCollider>();
            if (boxCollider != null)
            {
                boxCollider.enabled = false; // Disable the box collider
            }
            MeshCollider meshCollider = objectInHand.GetComponent<MeshCollider>();
            if (meshCollider != null)
            {
                meshCollider.enabled = false; // Disable the mesh collider
            }
            isHoldingObject = true;

            MeshFilter meshFilter = objectInHand.GetComponent<MeshFilter>();
            if (meshFilter != null) // Center the object in the screen
            {
                Vector3 localSize = meshFilter.mesh.bounds.size;
                float uprightHeight = localSize.y;
                float halfHeight = uprightHeight * 0.5f;
                Transform cameraTransform = GameObject.Find("PlayerCamera").transform;
                Vector3 positionInFrontOfCamera = cameraTransform.position + cameraTransform.forward *1.5f;
                Vector3 adjustedPosition = positionInFrontOfCamera - (cameraTransform.up * halfHeight);
                objectInHand.transform.position = adjustedPosition;
                objectInHand.transform.rotation = cameraTransform.rotation;
                objectInHand.transform.SetParent(cameraTransform);
            }
            else
            {
                Debug.LogError("MeshFilter not found. Make sure your object has a MeshFilter component.");
            }
        }

		else if(objectClone.CompareTag("Toggle")) //THIS IS LAZY CODING LMAOOOO PUT IT IN ANOTHER SCRIPT (// statement for remote controlling tv) 
		{
			Debug.Log("Toggled");
			remote.SetActive(true);
		}
    }

    public void HideItem() //deletes clone and enables movement 
    {
        //itemPickUp.SetActive(false);
        //gameItem.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fpc.setMoveBoolTrue();
        fpc.cameraCanMove = true;
		obCloning.DeleteObject();
    }

    public void DropItem() // Logic to drop the item the player is holding
    {
        objectInHand.transform.SetParent(null); // Removes object from the parent(PlayerCamera)
        Rigidbody rb = objectInHand.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false; // Enable physics interactions
        }
        BoxCollider boxCollider = objectInHand.GetComponent<BoxCollider>();
        if (boxCollider != null)
        {
            boxCollider.enabled = true; // Enable the box collider
        }
        MeshCollider meshCollider = objectInHand.GetComponent<MeshCollider>();
        if (meshCollider != null)
        {
            meshCollider.enabled = true; // Enable the mesh collider
        }
        objectInHand.transform.rotation = Quaternion.identity;
        objectInHand = null; //deletes the reference to object to reset
    }

    public void setTrue() //changes boolean for being able to pick object (old function) 
    {
        canPickUp = true;
    }

    public void setFalse() //changes boolean for being able to pick up object (old function)
    {
        canPickUp = false;
    }

    public void changeObjectName(string newName) //not in use? 
    {
        uiObject = newName;
    }
}
