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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public  void SetUIObject(Text UIObjectText, Canvas canvas)
    {
        textUI = UIObjectText;
        gameCanvas = canvas;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == PLAYER_TAG)
        {
            textUI.text = "The code is: 1234";
            gameCanvas.GetComponent<ButtonEffects>().StartDeleteUITextCoroutime(3.0f);
            Destroy(this.gameObject);
        }
    }
}
