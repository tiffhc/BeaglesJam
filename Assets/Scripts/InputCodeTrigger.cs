using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputCodeTrigger : MonoBehaviour
{
    [SerializeField] private bool End; 
    [SerializeField] EnterCodeManager minigame = null;
    [SerializeField] private string code = "";
    [SerializeField] private Transform lastCameraPosition = null;
    [SerializeField] private DoorBehaviour[] doors = null;

    public void SolveCode(bool solved)
    {
        Camera.main.transform.position = lastCameraPosition.position;
        if(solved)
        {

            if(this.gameObject.name == "Beagles_robotarm_1")
            {
                SceneManager.LoadScene("WinGame"); 
            }
            else
            {
                foreach (DoorBehaviour door in doors)
                {
                    door.isDoorUnlocked = true;
                }

            }
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.name == "Beagles_robotarm_1")
        {
            StartMinigame(); 
        }
    }

    public void StartMinigame()
    {
        minigame.SetCorrectCode(code);
        minigame.SetTriggerRef(this);
        minigame.UpdatePlaying();
    }
}
