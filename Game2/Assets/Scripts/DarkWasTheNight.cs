using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkWasTheNight : MonoBehaviour
{
    public Light lt;
    private bool isDarkening = false;
    private bool isBrightening = true;
    public float time=20;

	void Start ()
    {
    }
	
	void Update () {

        if (lt.gameObject.transform.rotation.eulerAngles.x > 175)
        {
            if(!isDarkening)
            {
                isDarkening = true;
                isBrightening = false;
            }
        }

        else
        {
            if(!isBrightening)
            {
                isBrightening = true;
                isDarkening = false;
            }
        }

        if (isDarkening)
        {
            if(lt.intensity>0)
            {
                lt.intensity -= 0.5f * (Time.deltaTime / time);
            }
        }
        if(isBrightening)
        {
            if(lt.intensity<0.9f)
            {
                lt.intensity += 0.5f * (Time.deltaTime / time);
            }
        }

    }
}
