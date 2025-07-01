/*
	Christopher Isidro
	2370110
	cisidro@chapman.edu
	CPSC-340-01
	Roommate Rescue

	Function: Functionality of the keypad.  This handles the buttons along with OK and CLEAR.  This also uses a function to get the player out of the room.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Keypad : MonoBehaviour

{
    public string puzzleCode; //puzzle code is determined per scene in the inspector
    public Text keypadText; //handles the current string of what is typed in the keypad

    private string keypadCode;
    // Start is called before the first frame update

    public void onPressZero() //the following functions add its respective value to a string, keypadCode
    {
        keypadCode += "0";
        keypadText.text = keypadCode;
    }
    public void onPressOne()
    {
        keypadCode += "1";
        keypadText.text = keypadCode;
    }

    public void onPressTwo()
    {
        keypadCode += "2";
        keypadText.text = keypadCode;
    }

    public void onPressThree()
    {
        keypadCode += "3";
        keypadText.text = keypadCode;
    }

    public void onPressFour()
    {
        keypadCode += "4";
        keypadText.text = keypadCode;
    }

    public void onPressFive()
    {
        keypadCode += "5";
        keypadText.text = keypadCode;
    }

    public void onPressSix()
    {
        keypadCode += "6";
        keypadText.text = keypadCode;
    }

    public void onPressSeven()
    {
        keypadCode += "7";
        keypadText.text = keypadCode;
    }

    public void onPressEight()
    {
        keypadCode += "8";
        keypadText.text = keypadCode;
    }

    public void onPressNine()
    {
        keypadCode += "9";
        keypadText.text = keypadCode;
    }

    public void onPressClear() //resets current string
    {
        keypadCode = "";
        keypadText.text = keypadCode;
    }

    public void onPressOk() //submits current string and checks to see if it matches the puzzle code
    {
        if (keypadCode == puzzleCode)
        {
            Debug.Log("Correct");
            keypadCode = "";
            keypadText.text = keypadCode;
            GameData.levelsCompleted++; //added to update game data
            GameData.SaveData();
			SceneManager.LoadScene (sceneName:"Main Menu");
        }
        else
        {
            Debug.Log("Incorrect");
            keypadCode = "";
            keypadText.text = keypadCode;
        }
    }

}
