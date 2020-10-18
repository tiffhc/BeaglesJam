using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    Vector2 movement;
    public float moveSpeed = 1.0f;
    public bool isMovementDisabled = false;

    public Animator animator;

    [FMODUnity.EventRef]
    public string footstepsSound = "";
    private float footstepsRatePerSecond = 0.4f;
    bool characterIsMoving;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PlayFootstepsSound", 0, footstepsRatePerSecond);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            DisableMovement();
        }

        if (Input.GetAxis("Vertical") >= 0.01f || Input.GetAxis("Horizontal") >= 0.01f || Input.GetAxis("Vertical") <= -0.01f || Input.GetAxis("Horizontal") <= -0.01f) 
        {
            //flip player if moving to the right
            if (Input.GetAxis("Horizontal") >= 0.01f)
            {
                transform.localScale = new Vector3(-0.4f, 0.4f, 1);
            }
            else if (Input.GetAxis("Horizontal") <= -0.01f) //flip back if player is moving to the left
            {
                transform.localScale = new Vector3(0.4f, 0.4f, 1);
            }
            characterIsMoving = true;
            animator.SetBool("Running", true);
        } 
        else if (Input.GetAxis ("Vertical") == 0 || Input.GetAxis ("Horizontal") == 0) 
        {
            characterIsMoving = false;
            animator.SetBool("Running", false);
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

    void PlayFootstepsSound()
    {
        if(isMovementDisabled)
        {
            return;
        }
        if (characterIsMoving == true)
        {
            FMODUnity.RuntimeManager.PlayOneShot(footstepsSound);
        }
    }

    public void DisableMovement()
    {
        isMovementDisabled = !isMovementDisabled;
    }
}
