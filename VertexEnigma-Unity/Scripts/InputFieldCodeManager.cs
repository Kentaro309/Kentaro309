/*
	Christopher Isidro
	2370110
	cisidro@chapman.edu
	CPSC-340-01
	Roommate Rescue

	Function: This script handles the input fields, comparing a string to different room codes.  It then calls level manager to start a scene.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFieldCodeManager : MonoBehaviour
{
    private string codeInput; //code input by user 
    public LevelManager levelManager; //reference to Level Manager
	
	public void ReadStringInput(string s) //Takes in user input upon pressing enter 
	{
		codeInput = s;
		Debug.Log(codeInput);
		if (s == "1234") //tutorial room - potentially change to a case statement 
		{
			Debug.Log("correct input");
			levelManager.StartTutorialP1();
		}  // other if-statements for actual levels 
		else if (s == "4321") //tutorial room - potentially change to a case statement 
		{
			Debug.Log("correct input");
			levelManager.StartTutorialP2();
		}
		else if (s == "2468")
		{
			levelManager.StartLevel1P1();
		}
		else if (s == "8642")
		{
			levelManager.StartLevel1P2();
		}
		else
		{
			Debug.Log("Game code not found");
		}
	} // modularity note: case statement with other game codes

}
