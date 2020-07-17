using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController charCont;
    Animator anim;

    [SerializeField]
    private float speed = 7f;
    [SerializeField]
    private float jumpForce = 7f;
    private const float gravity = 25f;

    // movement vector
    private Vector3 moving;
    private Vector3 lastPosition;
    private void Start() 
    {
        charCont = GetComponent<CharacterController>();
        moving = Vector3.zero;
        lastPosition = Vector3.zero;
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 horizontalVelocity = charCont.velocity;
        horizontalVelocity = new Vector3(charCont.velocity.x, 0, charCont.velocity.z);
        float horizontalSpeed = horizontalVelocity.magnitude;

        if(charCont.isGrounded) //Check if character is touching ground
        {
            moving = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")); // Horizontal Movement
            moving *= speed;

            if(Input.GetKey(KeyCode.LeftShift)) //Sprinting
            {
                speed = 12f;
            }
            else {speed = 7f;}

            if(Input.GetButton("Jump")) // Jumping
            {
                moving.y = jumpForce;
            }
            anim.SetFloat("Speed", horizontalSpeed);
        }

        moving.y-= gravity * Time.deltaTime; //Gravity

        //move
        charCont.Move(moving*Time.deltaTime);
    }
}
