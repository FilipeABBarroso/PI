using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;

    float horizontalMove = 0f;
    public float runSpeed;
    private float currentSpeed;

    bool jump = false;
    bool crouch = false;
    
    void Start()
    {
        currentSpeed = runSpeed;
    }

    // Update is called once per frame
    void Update() {

        horizontalMove = Input.GetAxisRaw("Horizontal") * currentSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("isJumping", true);
        }
        
        if(Input.GetButtonDown("Crouch")){
            crouch = true;
            currentSpeed = 0f;

        } else if (Input.GetButtonUp("Crouch")) {
            crouch = false;
            currentSpeed = runSpeed;
        }
    }
    void FixedUpdate() { 
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void onCrouching(bool isCrouching) {
        animator.SetBool("isCrouching", isCrouching);
    }

    public void onLanding() {
        animator.SetBool("isJumping", false);
    }
}
