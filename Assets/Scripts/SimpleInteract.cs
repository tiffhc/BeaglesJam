using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleInteract : MonoBehaviour
{
    // Start is called before the first frame update

    string PLAYER_TAG = "Player";
    [SerializeField] Text GameText;
    [SerializeField] string TextToDisplay = "TEXT HERE PLEASE";
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == PLAYER_TAG)
        {
            other.gameObject.GetComponent<CharacterController>().DisableMovement();
            GameText.text = TextToDisplay;
        }
    }
}
