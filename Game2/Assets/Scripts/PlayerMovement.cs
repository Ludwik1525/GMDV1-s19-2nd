using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;

    public float movementSpeed = 10;
    public float rotationSpeed = 5;
    public float rotationDegrees = 90;
    public float runningSpeed = 30;
    public float backwardsSpeed = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //moving forward and rotating to the left simultaneously
            if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    rb.position += transform.forward * Time.deltaTime * runningSpeed;
                }
                else
                {
                    rb.position += transform.forward * Time.deltaTime * movementSpeed;
                    rb.transform.Rotate(0f, -(rotationDegrees) * Time.deltaTime * rotationSpeed, 0f);
                }
            }

            //moving forward and rotating to the right simultaneously
            else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    rb.position += transform.forward * Time.deltaTime * runningSpeed;
                }
                else
                {
                    rb.position += transform.forward * Time.deltaTime * movementSpeed;
                    rb.transform.Rotate(0f, rotationDegrees * Time.deltaTime * rotationSpeed, 0f);
                }
            }
            //moving forward
            else if (Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                rb.position += transform.forward * Time.deltaTime * runningSpeed;
            }
            else
            {
                rb.position += transform.forward * Time.deltaTime * movementSpeed;
            }
        }

        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.Space))
        {
            //moving backwards and rotating to the left simultaneously
            if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                rb.position -= transform.forward * Time.deltaTime * backwardsSpeed;
                rb.transform.Rotate(0f, -(rotationDegrees) * Time.deltaTime * rotationSpeed, 0f);
            }

            //moving backwards and rotating to the right simultaneously
            else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                rb.position -= transform.forward * Time.deltaTime * backwardsSpeed;
                rb.transform.Rotate(0f, rotationDegrees * Time.deltaTime * rotationSpeed, 0f);
            }

            //moving backwards
            else
            {
                rb.position -= transform.forward * Time.deltaTime * backwardsSpeed;
            }
        }

        else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S))
        {
            rb.transform.Rotate(0f, -(rotationDegrees) * Time.deltaTime * rotationSpeed, 0f);
        }

        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
        {
            rb.transform.Rotate(0f, rotationDegrees * Time.deltaTime * rotationSpeed, 0f);
        }
    }
}
