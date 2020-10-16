using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterCodeManager : MonoBehaviour
{
    // TODO: Make the text for losing disappear after a second so player understands they can retry the passcode
    // TODO: Link to game code where it starts playing when interacting (interaction object gives the minigame the code)
    //and stops playing after player clicked quit or entered the correct code (return this result somewhere for game state control)


    [SerializeField] private Text codeText = null; // TODO: remove because this is for debug
    [SerializeField] private Text inputText = null;
    private string correctCode;
    private string inputCode;
    private bool playing; // Determines if this game is being played
    private int codeLength;

    // Start is called before the first frame update
    void Start()
    {
        correctCode = null;
        inputCode = null;
        playing = false;
        codeLength = 0;
    }

    void Update()
    {
        // Cast ray from mouse if playing
        if(playing)
        {
            // TODO: Hardcoded input, check this later maybe
            if(Input.GetMouseButtonDown(0))
            {
                // Cast a ray from camera through the mouse position onto the scene
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit))
                {
                    // Get value from button if it's a button
                    // TODO: Maybe tag the buttons to simplify this process
                    //Debug.Log("Ray hit: " + hit.collider.gameObject.name);
                    CodeButton cb = hit.collider.gameObject.GetComponent<CodeButton>();
                    int v;
                    if(cb != null)
                    {
                        v = cb.GetValue();
                        // update UI and value
                        UpdateInputCode(v.ToString());
                    }
                }
            }
        }
    }

    // Updates the code that solves the minigame
    public void SetCorrectCode(string newCorrectCode)
    {
        correctCode = newCorrectCode;

        // update debug UI
        // TODO: remove later
        codeText.text = correctCode;
    }

    // Updates the code that has been inputted by player
    //(this is supposed to be called by the sprites as they are clicked)
    public void UpdateInputCode(string newNumber)
    {
        inputCode += newNumber;
        // Update UI
        inputText.text = inputCode;

        // check if it's correct
        if (inputCode == correctCode)
        {
            // WIN
            //Debug.Log("CORRECT CODE!!");
            inputText.text = "CORRECT!";
            playing = !playing;
        }
        else if (inputCode.Length == codeLength)
        {
            // LOSE
            //Debug.Log("WRONG CODE!!");
            inputText.text = "INCORRECT!";
            playing = !playing;
        }
    }

    // Switches the state of the minigame
    public void UpdatePlaying()
    {
        playing = true;

        // TODO: Remove later
        // Debug code to test
        correctCode = "12341";
        codeLength = correctCode.Length;
        codeText.text = correctCode;
        inputCode = "";
        inputText.text = "";
    }
}
