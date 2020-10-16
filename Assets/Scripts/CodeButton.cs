using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeButton : MonoBehaviour
{
    [SerializeField] private int buttonValue = -1;

    public int GetValue()
    {
        return buttonValue;
    }
}
