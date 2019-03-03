using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Thirst : MonoBehaviour
{

    public UnityEngine.UI.Image thirstBarEmpty;
    public UnityEngine.UI.Image healthBarEmpty;
    public float fullThirst;
    public float emptyThirst;
    //variable to store rate of dehydration while not running
    public float dehydrationRateNormal;
    //variable to store rate of dehydration while running
    public float dehydrationRateRunning;
    public float dehydrationRateReflector;
    //variable to determine whether the player entered drink
    public bool enterDrink;
    //variable to store amount of health restored by drink
    public float thirstRestore;
    //variable to store current x coordinate of thirst bar
    public float currentThirstX;
    public float emptyHealth;
    //variable to store current x coordinate of health bar
    //variable to set HP loss rate if thirst bar is empty
    public float HPlossRate;
    public GameObject reflector;
    private Health healthScript;

    void Start()
    {
        //assign health bar and thirst bar x coordinates to max health at first
        currentThirstX = thirstBarEmpty.GetComponent<RectTransform>().anchoredPosition.x;
        healthScript = GetComponent<Health>();
    }

    void Update()
    {
        

        if (currentThirstX > emptyThirst)
        {
            //set thirst loss while running
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Space))
            {
                if (reflector.gameObject.tag == "LightOn")
                {
                    thirstBarEmpty.transform.position -=
                        new Vector3(1f * Time.deltaTime * (dehydrationRateRunning + dehydrationRateReflector), 0, 0);
                    currentThirstX -= 1f * Time.deltaTime * (dehydrationRateRunning + dehydrationRateReflector);
                }
                else
                {
                    thirstBarEmpty.transform.position -=
                        new Vector3(1f * Time.deltaTime * dehydrationRateRunning, 0, 0);
                    currentThirstX -= 1f * Time.deltaTime * dehydrationRateRunning;
                }
            }
            //set thirst loss while not running
            else
            {
                if (reflector.gameObject.tag == "LightOn")
                {
                    thirstBarEmpty.transform.position -=
                        new Vector3(1f * Time.deltaTime * dehydrationRateReflector, 0, 0);
                    currentThirstX -= 1f * Time.deltaTime * dehydrationRateReflector;
                }
                else
                {
                    thirstBarEmpty.transform.position -= new Vector3(1f * Time.deltaTime * dehydrationRateNormal, 0, 0);
                    currentThirstX -= 1f * Time.deltaTime * dehydrationRateNormal;
                }
            }
        }

        //set what happens when thirst bar is empty
        if (currentThirstX <= emptyThirst)
        {
            if (healthScript.currentX > emptyHealth)
            {
                healthBarEmpty.transform.position -= new Vector3(1f * Time.deltaTime * HPlossRate, 0, 0);
                healthScript.currentX -= 1f * Time.deltaTime * HPlossRate;
            }

        //load defeat scene when health bar is empty
            if (healthScript.currentX <= emptyHealth)
            {
                SceneManager.LoadScene("Defeat");
            }
        }

    //restore thirst
    if (enterDrink)
        {
            if (currentThirstX + thirstRestore > fullThirst)
            {
                thirstBarEmpty.transform.position += new Vector3(fullThirst-currentThirstX, 0, 0);
                currentThirstX = fullThirst;
                enterDrink = false;
            }
            else
            {
                thirstBarEmpty.transform.position += new Vector3(thirstRestore, 0, 0);
                currentThirstX += thirstRestore;
                enterDrink = false;
            }
        }
    }

    //function to determine whether the player entered any drink
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Drink")
        {
            if (currentThirstX < fullThirst)
            {
                enterDrink = true;
                col.transform.gameObject.tag = "Eaten";
            }
        }

        if (col.gameObject.tag == "Drink2")
        {
            if (currentThirstX < fullThirst)
            {
                enterDrink = true;
                col.gameObject.SetActive(false);
            }
        }
    }
}
