using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEffects : MonoBehaviour
{
    //Script to be held on the Canvas
    //This script should hold all the UI functionality. 

    [SerializeField] GameObject playerObject;
    [SerializeField] Text TextUI;
    


   public  void AllowPlayerMovement()
    {
        //OnClick, allow the player to begin moving again. Should Also hide all text, and stuff. 
        //Also hide the button

        playerObject.GetComponent<CharacterController>().DisableMovement();
        TextUI.text = "";

    }
}
