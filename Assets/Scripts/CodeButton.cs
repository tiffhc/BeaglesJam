using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeButton : MonoBehaviour
{

    [FMODUnity.EventRef]
    public string sound = "";

    [SerializeField] private int buttonValue = -1;

    public int GetValue()
    {
        FMODUnity.RuntimeManager.PlayOneShot(sound);
        return buttonValue;
    }
}
