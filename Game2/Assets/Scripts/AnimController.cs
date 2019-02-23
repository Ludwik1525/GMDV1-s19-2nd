using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimController : MonoBehaviour
{

    public Animator anim;

    void Start ()
    {
        anim = GetComponent<Animator>();
    }

    //a bool for determining whether the player is already in idle state or not
    public bool isIdle = false;
    //bool for determining whether the player is in the air or not
    public bool isGrounded;

    //function to determine whether the player is in the air or not
    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Update () {

        //if the player is on the ground
        if(isGrounded)
        {
            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) &&
                !Input.GetKey(KeyCode.Space))
            {
                //animation for slow walking forward
                if (Input.GetKey(KeyCode.S))
                {
                    anim.Play("SlowWalk");
                    isIdle = false;
                }
                //animation for normal walking or turning around
                else
                {
                    anim.Play("Walk");
                    isIdle = false;
                }
            }

            
            if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.W))
            {
                //animation for jumping
                if (Input.GetKeyDown(KeyCode.E))
                {
                    anim.Play("Jump");
                    isIdle = false;
                    isGrounded = false;
                }
                //animation for running
                else
                {
                    anim.Play("Run");
                    isIdle = false;
                }
            }

            if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.Space))
            {
                //animation for slow walking forward
                if (Input.GetKey(KeyCode.W))
                {
                    anim.Play("SlowWalk");
                    isIdle = false;
                }
                //animation for going backwards
                else
                {
                    anim.Play("SlowWalk");
                    isIdle = false;
                }
            }


            //go to idle state if no key is pressed, then change the bool to true so it will happen only once
            if (!Input.anyKey || (Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.W)))
            {
                if (!isIdle)
                {
                    anim.Play("Idle_0");
                }

                isIdle = true;
            }
        }
    }

}
