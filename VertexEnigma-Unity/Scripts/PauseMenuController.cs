using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{

    public GameObject pauseMenu;

    public void OnButtonPressMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void OnButtonPressResume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
