/*
	Function: Introduced initially as a debugger to double-check if buttons were working 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{

    public GameObject newGamePanel;
    public GameObject playerChoosePanel;
    // Start is called before the first frame update
    public GameObject howToPlayPanel1;
    public GameObject howToPlayPanel2;
    public GameObject howToPlayPanel3;
    public GameObject howToPlayPanel4;
    public GameObject DebugMenuPanel;
    void Start()
    {
        playerChoosePanel.SetActive(false);
        newGamePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPressPlay()
    {
        Debug.Log("Play");
    }

    public void OnButtonPressQuit()
    {
        Debug.Log("Quit");
        Application.Quit(); //Won't work in editor, only in build TESTME AFTER BUILD
    }

    public void OnButtonPressHub()
    {
        if (GameData.playerNumber == 1)
        {
            SceneManager.LoadScene("Hub");
        }
        else if (GameData.playerNumber == 2)
        {
            SceneManager.LoadScene("HubP2");
        }
    }

    public void OnButtonDeleteSaveData()
    {
        GameData.DeleteData();
        HideNewGamePanel();
        playerChoosePanel.SetActive(true);
    }

    public void ShowDeleteDataMenu()
    {
        newGamePanel.SetActive(true);
    }

    public void OnButtonPressPlayer1()
    {
        GameData.playerNumber = 1;
        GameData.SaveData();
        OnButtonPressHub();
    }

    public void OnButtonPressPlayer2()
    {
        GameData.playerNumber = 2;
        GameData.SaveData();
        OnButtonPressHub();
    }

    public void HidePlayerChoosePanel()
    {
        playerChoosePanel.SetActive(false);
    }

    public void HideNewGamePanel()
    {
        newGamePanel.SetActive(false);
    }
    public void ShowHowToPlay1()
    {
        howToPlayPanel1.SetActive(true);
    }
    public void ShowHowToPlay2()
    {
        howToPlayPanel2.SetActive(true);
    }
    public void ShowHowToPlay3()
    {
        howToPlayPanel3.SetActive(true);
    }
    public void ShowHowToPlay4()
    {
        howToPlayPanel4.SetActive(true);
    }
    public void ShowDebugMenu()
    {
        DebugMenuPanel.SetActive(true);
    }
    public void HideHowToPlay1()
    {
        howToPlayPanel1.SetActive(false);
    }
    public void HideHowToPlay2()
    {
        howToPlayPanel2.SetActive(false);
    }
    public void HideHowToPlay3()
    {
        howToPlayPanel3.SetActive(false);
    }
    public void HideHowToPlay4()
    {
        howToPlayPanel4.SetActive(false);
    }
    public void HideDebugMenu()
    {
        DebugMenuPanel.SetActive(false);
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
