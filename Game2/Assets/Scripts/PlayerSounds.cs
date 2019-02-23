using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{

    public AudioClip running;
    public AudioClip walking;
    public AudioClip goingBackwards;
    public AudioSource source;

    void Start ()
    {
    }

    //bool for determining whether the sound is already being played or not
    public bool isPlaying = false;
    //bool for determining whether the player is already running or not
    public bool isRunning = false;
    //bool for determining whether the player is already walking or not
    public bool isWalkingBack = false;
    //bool for determining whether the player is in the air or not
    public bool isGrounded;

    //function to determine whether the player is in the air or not
    void OnCollisionStay()
    {
        isGrounded = true;
        source.enabled = true;
    }

    void Update () {

        //sound for going backwards
        if (Input.GetKey(KeyCode.S))
        {
            if (!isPlaying)
            {
                source.loop = true;
                source.clip = goingBackwards;
                source.Play();
                isPlaying = true;
            }
        }
        
        //disable sound while jumping
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(isGrounded)
            {
                source.enabled = false;
            }
        }

        //sounds for walking and running
        if (Input.GetKey(KeyCode.W))
        {
            //sound for running
            if (Input.GetKey(KeyCode.Space))
            {
                if (!isRunning)
                {
                    source.Stop();
                    isRunning = true;
                    isPlaying = false;
                }

                if (!isPlaying)
                {
                    source.loop = true;
                    source.clip = running;
                    source.Play();
                    isPlaying = true;
                }
            }

            //sound for slow walking forward
            else if (Input.GetKey(KeyCode.S))
            {
                if (!isWalkingBack)
                {
                    source.Stop();
                    isWalkingBack = true;
                    isPlaying = false;
                }

                if (!isPlaying)
                {
                    source.loop = true;
                    source.clip = goingBackwards;
                    source.Play();
                    isPlaying = true;
                }
            }

            //sound for normal walking
            else
            {
                if(isRunning)
                {
                    source.Stop();
                    isRunning = false;
                    isPlaying = false;
                }

                if (!isPlaying)
                {
                    source.loop = true;
                    source.clip = walking;
                    source.Play();
                    isPlaying = true;
                }
            }
        }

        //sound for turning around
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (!isPlaying)
            {
                source.loop = true;
                source.clip = goingBackwards;
                source.Play();
                isPlaying = true;
            }
        }

        if (!Input.anyKey || (Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.W)))
        {
            source.Stop();
            isPlaying = false;
            isRunning = false;
            isWalkingBack = false;
        }
    }
}
