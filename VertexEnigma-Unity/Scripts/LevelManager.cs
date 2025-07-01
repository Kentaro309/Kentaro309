/*
	Function: script to hold functions to load different levels when called on
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // the functions below change the scene to its respective scene when called on
    public void StartTutorialP1()
    {
        SceneManager.LoadScene (sceneName:"Tutorial Room P1");
    }
    
    public void StartTutorialP2()
    {
        SceneManager.LoadScene (sceneName:"Tutorial Room P2");
    }

    public void StartLevel1P1()
    {
        SceneManager.LoadScene(sceneName: "Level 1 P1");
    }
    
    public void StartLevel1P2()
    {
        SceneManager.LoadScene(sceneName: "Level 1 P2");
    }
}
