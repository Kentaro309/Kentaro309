/*
    Function: Controls the logic for the keypad
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeypadUIController : MonoBehaviour
{

    public List<Sprite> images = new List<Sprite>();
    public List<Sprite> numbers = new List<Sprite>();
    public List<Sprite> correctSequence = new List<Sprite>();
    public Image displayImage1;
    public Image displayImage2;
    public Image displayImage3;
    public Image displayImage4;
    public Image displayImage5;
    private int currentIndex1 = 0;
    private int currentIndex2 = 0;
    private int currentIndex3 = 0;
    private int currentIndex4 = 0;
    private int currentIndex5 = 0;
    void Start()
    {
        displayImage1.sprite = images[0]; // Show the first image initially
        displayImage2.sprite = numbers[0];
        displayImage3.sprite = images[0];
        displayImage4.sprite = numbers[0];
    }
    
    public void onButtonUp1Click()
    {
        if (currentIndex1 == 8)
        {
            currentIndex1 = 0;
        }
        else
        {
            currentIndex1++;
        }
        displayImage1.sprite = images[currentIndex1];
    }

    public void onButtonUp2Click()
    {
        if (currentIndex2 == 8)
        {
            currentIndex2 = 0;
        }
        else
        {
            currentIndex2++;
        }
        displayImage2.sprite = numbers[currentIndex2];
    }

    public void onButtonUp3Click()
    {
        if (currentIndex3 == 8)
        {
            currentIndex3 = 0;
        }
        else
        {
            currentIndex3++;
        }
        displayImage3.sprite = images[currentIndex3];
    }
    public void onButtonUp4Click()
    {
        if (currentIndex4 == 8)
        {
            currentIndex4 = 0;
        }
        else
        {
            currentIndex4++;
        }
        displayImage4.sprite = numbers[currentIndex4];
    }

    public void onButtonUp5Click()
    {
        if (currentIndex5 == 8)
        {
            currentIndex5 = 0;
        }
        else
        {
            currentIndex5++;
        }
        displayImage5.sprite = numbers[currentIndex5];
    }

    public void onButtonDown1Click()
    {
        if (currentIndex1 == 0)
        {
            currentIndex1 = 8;
        }
        else
        {
            currentIndex1--;
        }
        displayImage1.sprite = images[currentIndex1];
    }

    public void onButtonDown2Click()
    {
        if (currentIndex2 == 0)
        {
            currentIndex2 = 8;
        }
        else
        {
            currentIndex2--;
        }
        displayImage2.sprite = numbers[currentIndex2];
    }

    public void onButtonDown3Click()
    {
        if (currentIndex3 == 0)
        {
            currentIndex3 = 8;
        }
        else
        {
            currentIndex3--;
        }
        displayImage3.sprite = images[currentIndex3];
    }
    public void onButtonDown4Click()
    {
        if (currentIndex4 == 0)
        {
            currentIndex4 = 8;
        }
        else
        {
            currentIndex4--;
        }
        displayImage4.sprite = numbers[currentIndex4];
    }

    public void onButtonDown5Click()
    {
        if (currentIndex5 == 0)
        {
            currentIndex5 = 8;
        }
        else
        {
            currentIndex5--;
        }
        displayImage5.sprite = numbers[currentIndex4];
    }

    public void onButtonClickEnter()
    {
        if((images[currentIndex1] == correctSequence[0]) && (numbers[currentIndex2] == correctSequence[1]) && (images[currentIndex3] == correctSequence[2]) && (numbers[currentIndex4] == correctSequence[3]))
        {
            string sceneName = SceneManager.GetActiveScene().name;

            switch (sceneName) //Switch case to unlock levels based on current level
            {
                case "Level_01_P1":
                case "Level_01_P2":
                    GameData.level2 = 1;
                    break;
                case "Level_02_P1":
                case "Level_02_P2":
                    GameData.level3 = 1;
                    break;
                case "Level_03_P1":
                case "Level_03_P2":
                    GameData.level4 = 1;
                    break;
                case "Level_04_P1":
                case "Level_04_P2":
                    GameData.level5 = 1;
                    break;
                default:
                    Debug.Log("Level failed to unlock");
                    break;
            } 
            //GameData.levelsCompleted++; //added to update game data
            GameData.SaveData();
            if (GameData.playerNumber == 1)
            {
                SceneManager.LoadScene("Hub");
            }
            else if (GameData.playerNumber == 2)
            {
                SceneManager.LoadScene("HubP2");
            }
        }
    }

    public void onButtonClickEnter3lots()
    {
        if((images[currentIndex1] == correctSequence[0]) && (numbers[currentIndex2] == correctSequence[1]) && (images[currentIndex3] == correctSequence[2]))
        {
            GameData.levelsCompleted++; //added to update game data
            GameData.SaveData();
            if (GameData.playerNumber == 1)
            {
                SceneManager.LoadScene("Hub");
            }
            else if (GameData.playerNumber == 2)
            {
                SceneManager.LoadScene("HubP2");
            }
        }
    }
}
