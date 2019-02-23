using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {


    public Rigidbody rb;
    private bool pressedOnce = false;
    public Animator anim;

    void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	void Update () {

        if (Input.anyKeyDown && !pressedOnce)
        {
            anim.Play("Slide");
            Input.ResetInputAxes();
            pressedOnce = true;
        }

        if (Input.anyKeyDown && pressedOnce)
        {
            SceneManager.LoadScene("MainScene");
        }
	}
}
