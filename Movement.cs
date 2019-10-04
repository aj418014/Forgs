using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float speed = 5.0f; // a multiplier added to the movement of the player.
    float sprintModifier = 1.5f; // the modifier that leftshift adds
    public float jumpForce = 2.0f; //multiplier of the rigidbody.push of the jump.
    public float sensitivity = 10f; //sensitivity of the mouse
    private float finalSprintMod = 1; //decides if the sprint mod will be applied
    private Vector2 currentRotation; //used to facilitiate calculation of the rotation in the RotateObject section of the script
    private bool grounded;
    //public AudioSource flamethrowerSound; //depricated
    //public ParticleSystem flameThrower; //depricated

    private void Start()
    {
        //flameThrower.Stop(); deprecated code, carryovers from Burnie 2020(?)
    }//Start

    private void Update()
    {
        checkIfGrounded();
        Move();
        RotateObject();
        //if (Input.GetMouseButtonDown(1)) 
            //Cursor.lockState = CursorLockMode.Locked; //commented out because I think an FPS like frogs should omit a feature like this
        if (Input.GetMouseButtonDown(1)) //if lmb pressed
        {
            //flamethrowerSound.Play(); depricated
            //flameThrower.Play(); depricated
        }
        if(Input.GetMouseButtonUp(1)) //if lmb unpressed
        {
            //flamethrowerSound.Stop();
            //flameThrower.Stop(); another carryover from Burnie 2020 
        }

    }//Update

    private void Move() //seperated function for moving the player(model?)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            finalSprintMod = sprintModifier;
        }
        else
        {
            finalSprintMod = 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * finalSprintMod * Time.deltaTime); //translate player forward by the speed * deltatime
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * finalSprintMod * Time.deltaTime); //translate player left by the speed * deltatime
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * finalSprintMod * Time.deltaTime); //translate player forward by the speed * deltatime
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * finalSprintMod * Time.deltaTime); //translate player right by the speed * deltatime
        }
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
        }
    }//Move

    private void RotateObject() //seperated function for rotating the player(model?)
    {
        currentRotation.x += Input.GetAxis("Mouse X") * sensitivity; //sets the x component of the Vector2 'currentRotation' to be the movement of the mouse * sensitivity
        currentRotation.x = Mathf.Repeat(currentRotation.x, 360); //loops currentRotation.x so it is always greater than 0 and less than 360 then sets it to the currentrotation
        gameObject.transform.rotation = Quaternion.Euler(0, currentRotation.x, 0); //set the x transform of the player to be the x component of currentrotation
    }//Rotate Object


   private void checkIfGrounded()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, .6f); //returns true if player is close enough to the ground to jump. bonus points for bhopping.
    }

}//Movement class


