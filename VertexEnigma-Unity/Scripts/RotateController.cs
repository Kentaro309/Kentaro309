/*
	Christopher Isidro
	2370110
	cisidro@chapman.edu
	CPSC-340-01
	Roommate Rescue
	SOURCE: https://discussions.unity.com/t/drag-to-rotate-game-object-with-mouse/185366
	Function: Enables lateral rotation of objects using LMB.  In order to rotate an object, it needs a tag of PickUpable
*/

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]

public class RotateController : MonoBehaviour 
{

    #region ROTATE
    private float _sensitivity = 1f;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotation = Vector3.zero;
    public bool _isRotating;
    public KeyCode interactButton = KeyCode.E;
    
    #endregion

    void Update()
    {
        if(_isRotating)
        {
            // offset
            _mouseOffset = (Input.mousePosition - _mouseReference);

            // apply rotation
            _rotation.y = -(_mouseOffset.x) * _sensitivity;
            //_rotation.x = (_mouseOffset.y) * _sensitivity;

            // rotate
            if (gameObject.CompareTag("ClonedObject"))
            {
                gameObject.transform.Rotate(_rotation);
            }
            
            // store new mouse position
            _mouseReference = Input.mousePosition;
        }
    }

    void OnMouseDown()
    {
        // rotating flag
        _isRotating = true;

        // store mouse position
        _mouseReference = Input.mousePosition;
    }

    void OnMouseUp()
    {
        // rotating flag
        _isRotating = false;
    }

    public void SetRotatingFalse()
    {
        _isRotating = false;
    }


}