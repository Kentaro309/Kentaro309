/*
 * File: GameOver.cs
 * Author: Kentaro Matsuo
 * Created: 2024
 * Description: 
 * Unity Version: 2022.3 LTS
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{

    //public Timer timer;
    public GameObject gameOverPanel;
    public FirstPersonController fpc; //reference to fpc to change player movement restraints

    // Start is called before the first frame update
    void Awake()
    {
        gameOverPanel.SetActive(false);   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*if (timer.timeValue == 0f)
        {
            //Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None; // Unlock the cursor
            Cursor.visible = true;
            fpc.playerCanMove = false;
        	fpc.cameraCanMove = false;
            gameOverPanel.SetActive(true);
        }*/
    }

    public void loadHubLevel()
    {
        if (GameData.playerNumber == 1)
        {
            SceneManager.LoadScene("Hub");
        }
        if (GameData.playerNumber == 2)
        {
            SceneManager.LoadScene("HubP2");
        }
    }
}
