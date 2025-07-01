/*
	Function: Item Display is in charge of changing the text of the item that you are looking at in player UI 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemDisplayText : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text itemText; //item text object reference to link in game 
    public PickupLogic pickupLogic; //reference to pickup logic to grab object name
    void Start()
    {
        itemText.text = "";
    }


    public void changeText(string newText) //changes the text of player UI item text 
    {
        itemText.text = newText;
        //pickupLogic.changeObjectName(newText);
    }
}
