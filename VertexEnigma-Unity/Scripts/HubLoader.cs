using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubLoader : MonoBehaviour
{   
    public GameObject level2;
    public GameObject level2SetActive;
    public GameObject level3;
    public GameObject level3SetActive;
    public GameObject level4;
    public GameObject level4SetActive;
    public GameObject level5;
    public GameObject level5SetActive;
    void Start()
    {
        //Set all levels to inactive first
        level2.SetActive(false);
        level3.SetActive(false);
        level4.SetActive(false);
        level5.SetActive(false);

        /*if (GameData.levelsCompleted >= 1)
        {
            level2.SetActive(true);
            level2SetActive.SetActive(false);
        }
        if (GameData.levelsCompleted >= 2)
        {
            level3.SetActive(true);
            level3SetActive.SetActive(false);
        }
        if (GameData.levelsCompleted >= 3)
        {
            level4.SetActive(true);
            level4SetActive.SetActive(false);
        }
        if (GameData.levelsCompleted >= 4)
        {
            level5.SetActive(true);
            level5SetActive.SetActive(false);
        }*/

        if (GameData.level2 == 1)
        {
            level2.SetActive(true);
        }
        if (GameData.level3 == 1)
        {
            level3.SetActive(true);
        }
        if (GameData.level4 == 1)
        {
            level4.SetActive(true);
        }
        if (GameData.level5 == 1)
        {
            level5.SetActive(true);
        }
    }
}
