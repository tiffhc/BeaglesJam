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
    [SerializeField] Transform CameraMoveTo = null;
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


            if(CameraMoveTo != null)
            {
                Vector3 newPosition = new Vector3(CameraMoveTo.position.x,
                                                    CameraMoveTo.position.y,
                                                    Camera.main.transform.position.z);
                Camera.main.transform.position = newPosition;
            }
        }
    }
}
