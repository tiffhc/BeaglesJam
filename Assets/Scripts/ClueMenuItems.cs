using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueMenuItems : MonoBehaviour
{
    public bool isVisible = false;
    public Text clueDescription;
    public Image cluePicture;

    public Sprite thisSprite;
    [TextArea(3, 10)]
    public string thisClueSentences;

    public void ClueButtonClicked()
    {
        cluePicture.sprite = thisSprite;
        cluePicture.SetNativeSize();
        clueDescription.text = thisClueSentences;
    }
}
