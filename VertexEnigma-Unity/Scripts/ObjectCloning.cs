/*
	Christopher Isidro
	2370110
	cisidro@chapman.edu
	CPSC-340-01
	Roommate Rescue

	Function: In charge of cloning and deleting object received by raytrace to position in the middle of character's FOV
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCloning : MonoBehaviour
{
    public Camera characterCamera; //access to the player camera to put cloned object in view 
    private GameObject clonedObject;
    
    // Start is called before the first frame update
    public void CloneObject(GameObject objectToClone) //clones object in viewport of player 
    {
        Vector3 centerOfViewport = new Vector3(0.5f, 0.5f, 0.5f);
        Vector3 centerInWorld = characterCamera.ViewportToWorldPoint(centerOfViewport);
        clonedObject = Instantiate(objectToClone, centerInWorld, Quaternion.identity);
        Vector3 directionToFace = characterCamera.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(directionToFace);
        //clonedObject.transform.SetParent(characterCamera.transform);

        //clonedObject = objectToClone;
        //Debug.Log("Cloned");

        //changed so object appears in center of screen
        MeshFilter meshFilter = clonedObject.GetComponent<MeshFilter>();
        Vector3 localSize = meshFilter.mesh.bounds.size;
        float uprightHeight = localSize.y;
        float halfHeight = uprightHeight * 0.5f;
        Transform cameraTransform = GameObject.Find("PlayerCamera").transform;
        Vector3 positionInFrontOfCamera = cameraTransform.position + cameraTransform.forward *0.65f;
        Vector3 adjustedPosition = positionInFrontOfCamera - (cameraTransform.up * halfHeight);
        clonedObject.transform.position = adjustedPosition;
        if (clonedObject.CompareTag("Scrap"))
        {
            clonedObject.transform.rotation = characterCamera.transform.rotation * Quaternion.Euler(-90, 0, 0);
        }

        //clonedObject.transform.position -= Vector3.up * 0.15f;
        clonedObject.tag = "ClonedObject";
        clonedObject.layer = LayerMask.NameToLayer("ClonedLayer");
        //clonedObject.transform.rotation = Quaternion.Euler(targetRotation.eulerAngles.x -9, targetRotation.eulerAngles.y, targetRotation.eulerAngles.z + 40); //set cloned object to face player
        //Quaternion targetRotation = Quaternion.LookRotation(-characterCamera.transform.forward, directionToFace);
        //clonedObject.transform.rotation = Quaternion.Euler(90, 0, 0);
        //objectToClone.SetActive(false); //sets original object to false
    }

    public void DeleteObject() //removes cloned object 
    {
        Destroy(clonedObject);
    }
}
