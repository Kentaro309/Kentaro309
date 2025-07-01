/*
	Christopher Isidro
	2370110
	cisidro@chapman.edu
	CPSC-340-01
	Roommate Rescue

	Function: Handles the raytracing of looking and interacting with the keypad and uses the logic to keep the player in place to prevent them from moving.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadDisplay : MonoBehaviour
{
    public bool canInput = false; //determines if keypad can be interacted with if in the box collider
    private bool keypadEnabled; // UI of keypad enabled/disabled
    public GameObject keypad; //object reference to the keypad being displayed 
    public KeyCode interactButton = KeyCode.E; //defined interact button
    public FirstPersonController fpc; //reference to fps, for raytrace (i think this was later not used) 
    public Rigidbody PlayerRb;

    void Update() //checks for interact button and booleans to bring up keypad 
    {
        if (Input.GetKeyDown(interactButton) && canInput && !keypadEnabled)
        {
            ShowKeypad();
            PlayerRb.velocity = Vector3.zero;
        }
        else if ((Input.GetKeyDown(interactButton) || Input.GetKeyDown(KeyCode.Escape)) && keypadEnabled)
        {
            canInput = false;
            HideKeypad();
        }
    }

    public void ShowKeypad() //displays keypad and locks player movement and enables mouse
    {
        keypad.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        fpc.playerCanMove = false;
        fpc.cameraCanMove = false;
        keypadEnabled = true;
        GameData.canPause = false;
    }

    public void HideKeypad() //hides keypad and enables player movement and hides mouse 
    {
        keypad.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fpc.playerCanMove = true;
        fpc.cameraCanMove = true;
        keypadEnabled = false;
        GameData.canPause = true;
    }
    
}
