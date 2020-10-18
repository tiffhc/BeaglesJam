using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WireMinigameHandler : MonoBehaviour
{
    [SerializeField] private int totalWires = 0;
    private int wiresComplete = 0;
    private Wire holdingWire = null;
    private Wire endWireFound = null;
    private bool isHoldingWire = false;
    private bool isPlaying = false;

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            // Call for wire update if already dragging it
            if (isHoldingWire)
            {
                holdingWire.UpdateWire();
            }

            // Get mouse input and check if it's start
            if (Input.GetMouseButtonDown(0))
            {
                CheckWirePickup();
            }

            // Get mouse button up and if it's holding the wire, call the proper function
            if (Input.GetMouseButtonUp(0))
            {
                if (isHoldingWire)
                {
                    CheckWireRelease();
                }
            }
        }
    }

    private void CheckWirePickup()
    {
        // Cast for wire
        // Cast a ray from camera through the mouse position onto the scene
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            holdingWire = hit.collider.gameObject.GetComponent<Wire>();
            if (holdingWire != null)
            {
                if (holdingWire.IsWireStart() && !holdingWire.IsFinished())
                {
                    isHoldingWire = true;
                }
            }
        }
    }

    private void CheckWireRelease()
    {
        // Cast for wire end
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            endWireFound = hit.collider.gameObject.GetComponent<Wire>();
            if (endWireFound != null && isHoldingWire)
            {
                // TODO: maybe just put this entire check in the function call
                if (!(endWireFound.IsWireStart()) &&
                        (endWireFound.GetWireNumber() == holdingWire.GetWireNumber()))
                {
                    holdingWire.EndWire(true);
                    FinishedWire();
                }
                else
                {
                    holdingWire.EndWire(false);
                }

                isHoldingWire = false;
                // TODO: change this to a return to the proper game after minigame is complete inside the if
                //isPlaying = false;
            }
        }
        else
        {
            holdingWire.EndWire(false);
        }

        isHoldingWire = false;
        // TODO: change this to a return to the proper game after minigame is complete inside the if
        //isPlaying = false;
    }

    private void FinishedWire()
    {
        wiresComplete += 1;

        if(wiresComplete == totalWires)
        {
            isPlaying = false;
            Debug.Log("Complete!!");
        }
    }

    public void StartPlaying()
    {
        if (wiresComplete == 0)
        {
            isPlaying = true;
        }
    }
}
