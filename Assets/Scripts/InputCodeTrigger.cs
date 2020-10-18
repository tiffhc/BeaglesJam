using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCodeTrigger : MonoBehaviour
{
    [SerializeField] EnterCodeManager minigame = null;
    [SerializeField] private string code = "";
    [SerializeField] private Transform lastCameraPosition = null;
    [SerializeField] private DoorBehaviour[] doors = null;

    public void SolveCode(bool solved)
    {
        Camera.main.transform.position = lastCameraPosition.position;
        if(solved)
        {
            foreach (DoorBehaviour door in doors)
            {
                door.isDoorUnlocked = true;
            }
        }
    }

    public void StartMinigame()
    {
        minigame.SetCorrectCode(code);
        minigame.SetTriggerRef(this);
        minigame.UpdatePlaying();
    }
}
