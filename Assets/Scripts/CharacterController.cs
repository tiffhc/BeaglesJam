using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    Vector2 movement;
    public float moveSpeed = 1.0f;
    public bool isMovementDisabled = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            DisableMovement();
        }
        //Split movement into two steps, in case we want to move the chacter using somehting else, but here we get input accross the axis,
        //and then used moved character to move it around. 


        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        MoveCharacter();
    }

    void MoveCharacter()
    {
        if (isMovementDisabled)
        {
            return;
        }
        //Translates the character. 
        this.gameObject.transform.Translate(new Vector3(movement.x, movement.y, 0.0f).normalized * moveSpeed * Time.deltaTime);


    }

    public void DisableMovement()
    {
        isMovementDisabled = !isMovementDisabled;
    }


}
