using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    // Wire control
    [SerializeField] private Wire wireEnd = null;
    [SerializeField] private bool wireStart = false;
    [SerializeField] private int wireNumber = -1; // To check if it's the correct ending

    // Line control
    private LineRenderer line;
    private bool done = false;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        if(line != null)
        {
            Vector3 startPos = new Vector3(transform.position.x, transform.position.y, 0);
            line.SetPosition(0, startPos);
            line.SetPosition(1, startPos);
        }
    }

    // Function to compute ending of wire (called by mousebuttonUp)
        // If not at a proper ending, reset wire
    public void EndWire(bool correct)
    {
        if(correct)
        {
            Vector3 position = new Vector3(wireEnd.transform.position.x, wireEnd.transform.position.y, 0);
            line.SetPosition(1, position);
            done = true;
        }
        else
        {
            Vector3 position = new Vector3(transform.position.x, transform.position.y, 0);
            line.SetPosition(1, position);
        }
    }

    // Function to update line while having it hold
        // Update end point
    public void UpdateWire()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        line.SetPosition(1, new Vector3(mouse.x, mouse.y, 0));
    }

    public bool IsWireStart()
    {
        return wireStart;
    }

    public int GetWireNumber()
    {
        return wireNumber;
    }

    public bool IsFinished()
    {
        return done;
    }
}
