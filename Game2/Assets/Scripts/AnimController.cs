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
    bool isIdle = false;

	void Update () {

        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.Space))
        {
            anim.Play("Walk");
            isIdle = false;
        }

        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.W))
        {
            anim.Play("Run");
            isIdle = false;
        }

        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.Space))
        {
            anim.Play("Walk");
            isIdle = false;
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
