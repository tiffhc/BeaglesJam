using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CypherScript : MonoBehaviour
{
    // Start is called before the first frame update

    string PLAYER_TAG = "Player";
    [SerializeField] Text textUI;
    [SerializeField] Canvas gameCanvas;
    [SerializeField] int phoneNumber;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public  void SetUIObject(Text UIObjectText, Canvas canvas, int phoneNumber)
    {
        textUI = UIObjectText;
        gameCanvas = canvas;
        this.phoneNumber = phoneNumber;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == PLAYER_TAG)
        {
            textUI.text = "The code is: " + phoneNumber.ToString();
            gameCanvas.GetComponent<ButtonEffects>().StartDeleteUITextCoroutime(3.0f);
            Destroy(this.gameObject);
            GameObject GameManager = GameObject.FindGameObjectWithTag("GameManager");
            GameManager.GetComponent<GameManagerScript>().FoundPhoneNumber();
        }
    }
}
