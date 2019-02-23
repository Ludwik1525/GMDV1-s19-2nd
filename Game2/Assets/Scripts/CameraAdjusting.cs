using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjusting : MonoBehaviour {

    public Rigidbody rb;

    public float rotationSpeed = 5;
    public float rotationDegrees = 90;
    [SerializeField]
    private float eulerAngX;

    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	void FixedUpdate () {

        eulerAngX = transform.localEulerAngles.x;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (eulerAngX > 20)
            {
                rb.transform.Rotate(-(rotationDegrees) * Time.deltaTime * rotationSpeed, 0f, 0f);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if(eulerAngX<38)
            {
                rb.transform.Rotate((rotationDegrees) * Time.deltaTime * rotationSpeed, 0f, 0f);
            }
        }
        
    }
}
