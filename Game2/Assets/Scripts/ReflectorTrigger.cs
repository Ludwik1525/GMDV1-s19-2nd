using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorTrigger : MonoBehaviour {

    public GameObject reflector;
    
    void Start ()
    {
        reflector.SetActive(false);
        reflector.gameObject.tag = "LightOff";
    }
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (reflector.gameObject.tag == "LightOn")
            {
                reflector.SetActive(false);
                reflector.gameObject.tag = "LightOff";
            }
            else
            {
                reflector.SetActive(true);
                reflector.gameObject.tag = "LightOn";
            }
        }
    }
}
