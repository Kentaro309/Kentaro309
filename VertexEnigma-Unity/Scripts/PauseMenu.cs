/*
	Function: In charge of anything related to pause menu including logic for player movement and UI 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

	public bool isPaused = false; // "state" of being pased for script 
	public KeyCode pauseButton = KeyCode.Escape; //define pause button 
	public Canvas pauseMenu; //pause canvas 
	public FirstPersonController fpc; //reference to fpc to stop movement 

	void Update() //checks to see if game is paused to enable or disable menu 
	{
		if (isPaused)
        {
            if (isPaused && Input.GetKeyDown(pauseButton))
            {
				DisablePauseMenu();
                isPaused = false;
                
            }
        }

		else if (!isPaused)
        {
            if ((!isPaused && Input.GetKeyDown(pauseButton)) && GameData.canPause == true)
            {
				EnablePauseMenu();
                isPaused = true;
                
            }
        }
	}
	public void Pause() //function to change pause state 
	{
		isPaused = true;
	}

	public void UnPause() //function to change pause state 
	{
		isPaused = false;
	}
    public void EnablePauseMenu() //enabling pause menu covers logic for player movement and pauses the game 
	{
		Debug.Log("Paused in Script");
		pauseMenu.enabled = true;
		Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
		fpc.playerCanMove = false;
		fpc.cameraCanMove = false;
	}

	public void DisablePauseMenu() //relesases player movement and hides menu
	{
		Debug.Log("Unpaused in Script");
		pauseMenu.enabled = false;
		Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
		fpc.playerCanMove = true;
        fpc.cameraCanMove = true;
	}

	public void QuitToMainMenu() //changes the scene for quiting the level
	{
		SceneManager.LoadScene (sceneName:"Main Menu");
	}
}
