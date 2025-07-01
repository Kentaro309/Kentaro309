/*
    Function: Static class for storing/loading all of the game data
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData //Can be called from any script. Do not need to put this on an object (These comments are written for my teammates for when they need to use the script within the game engine).
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnGameStart() //This code runs once when the game starts, before any scene is loaded
    {
        LoadData();
    }

    // List of Game Data variables 
    public static int levelsCompleted = 0; //update this as the player progresses through levels. Copy: GameData.levelsCompleted++;
    public static int playerNumber = 0;
    public static float gameTimerL1 = 0f;
    public static float gameTimerL2 = 0f;
    public static float gameTimerL3 = 0f;
    public static bool canPause = true;

    public static int level2 = 0;
    public static int level3 = 0;
    public static int level4 = 0;
    public static int level5 = 0;

    public static void SaveData() //Saves data to player prefs. Put any data that you want to save here.
    {
        PlayerPrefs.SetInt("Levels Completed", levelsCompleted);
        PlayerPrefs.SetInt("Player", playerNumber);
        PlayerPrefs.SetFloat("GameTimerL1", gameTimerL1);
        PlayerPrefs.SetFloat("GameTimerL2", gameTimerL2);
        PlayerPrefs.SetFloat("GameTimerL3", gameTimerL3);
        PlayerPrefs.SetInt("Level 2 Unlocked", level2);
        PlayerPrefs.SetInt("Level 3 Unlocked", level3);
        PlayerPrefs.SetInt("Level 4 Unlocked", level4);
        PlayerPrefs.SetInt("Level 5 Unlocked", level5);
    }

    public static void LoadData() //Loads game data. Should be called when player first launches the game to load all save data.
    {
        levelsCompleted = PlayerPrefs.GetInt("Levels Completed");
        playerNumber = PlayerPrefs.GetInt("Player");
        gameTimerL1 = PlayerPrefs.GetFloat("GameTimerL1");
        gameTimerL2 = PlayerPrefs.GetFloat("GameTimerL2");
        gameTimerL3 = PlayerPrefs.GetFloat("GameTimerL3");
        level2 = PlayerPrefs.GetInt("Level 2 Unlocked");
        level3 = PlayerPrefs.GetInt("Level 3 Unlocked");
        level4 = PlayerPrefs.GetInt("Level 4 Unlocked");
        level5 = PlayerPrefs.GetInt("Level 5 Unlocked");
    }

    public static void DeleteData() //Resets the game to the initial state by deleting all of the player data.
    {
        levelsCompleted = 0;
        playerNumber = 0;
        gameTimerL1 = 0f;
        gameTimerL2 = 0f;
        gameTimerL3 = 0f;
        level2 = 0;
        level3 = 0;
        level4 = 0;
        level5 = 0;
        PlayerPrefs.DeleteAll();
    }

    //if (SceneManager.GetActiveScene().name == "Level_01_P1")
}
