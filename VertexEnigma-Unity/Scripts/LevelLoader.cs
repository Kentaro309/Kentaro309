using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string sceneNameToLoad; //Name of the scene you want to load

    private void OnTriggerEnter(Collider other) //Make sure 'is trigger' is enabled on object's collider
    {
        if (other.CompareTag("Player")) //Make sure player GameObject has the tag "Player"
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }
}