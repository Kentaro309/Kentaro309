/*
	Christopher Isidro
	2370110
	cisidro@chapman.edu
	CPSC-340-01
	Roommate Rescue

	Function: In charge of timer logic.  Time is set at ten minutes initially and counts to zero.  No lose screen is implemented yet.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
	//public float timeValue = GameData.gameTimer;
	public TMP_Text timeText; //reference to timer in game 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //checks timer to see if it hits zero
    {
		if ((SceneManager.GetActiveScene().name == "Level_01_P1") || (SceneManager.GetActiveScene().name == "Level_01_P2"))
		{
			GameData.gameTimerL1 += Time.deltaTime;
			DisplayTime(GameData.gameTimerL1);
		}
		else if ((SceneManager.GetActiveScene().name == "Level_02_P1") || (SceneManager.GetActiveScene().name == "Level_02_P2"))
		{
			GameData.gameTimerL2 += Time.deltaTime;
			DisplayTime(GameData.gameTimerL2);
		}
		else if ((SceneManager.GetActiveScene().name == "Level_03_P1") || (SceneManager.GetActiveScene().name == "Level_03_P2"))
		{
			GameData.gameTimerL3 += Time.deltaTime;
			DisplayTime(GameData.gameTimerL3);
		}
		//if(timeValue > 0)
		//GameData.gameTimer += Time.deltaTime;
		//else
		//timeValue = 0;
		//DisplayTime(GameData.gameTimer);
    }
	void DisplayTime(float timeToDisplay) //displays time and changes to hundredths of a second under ten seconds 
	{
		if(timeToDisplay < 0)
		{
			timeToDisplay = 0;
		}
		
		float minutes = Mathf.FloorToInt(timeToDisplay / 60);
		float seconds = Mathf.FloorToInt(timeToDisplay % 60);
		float milliseconds = timeToDisplay % 1 * 1000;
		
		/*if(timeToDisplay < 10)
			timeText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
		else*/
		timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
		
	}
}
