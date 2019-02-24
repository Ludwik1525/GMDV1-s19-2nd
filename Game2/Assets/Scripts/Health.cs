using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public UnityEngine.UI.Image healthBarEmpty;
    public float fullHealth;
    public float emptyHealth;
    //variable to set DMG dealt by obstacles
    public float obstaclesDMG;
    //variable to set DMG dealt by enemies
    public float enemiesDMG;
    //variable to determine whether the player entered an obstacle
    public bool enterObstacle;
    //variable to determine whether the player entered an enemy
    public bool enterEnemy;
    //variable to determine whether the player entered food
    public bool enterFood;
    //variable to store amount of health restored by food
    public float HPrestore;
    //variable to store current x coordinate of health bar
    public float currentX;
    
	void Start ()
    {
        //assign health bar x coordinate to max health at first
        currentX = healthBarEmpty.GetComponent<RectTransform>().anchoredPosition.x;
    }
	
	void Update () {

        if(enterObstacle)
        {
            //deal damage if obstacle entered
            if (currentX > emptyHealth)
            {
                healthBarEmpty.transform.position -= new Vector3(1f * Time.deltaTime * obstaclesDMG, 0, 0);
                currentX -= 1f * Time.deltaTime * obstaclesDMG;
                this.gameObject.tag = "PlayerHurt";
            }

            //load defeat scene if health below 0
            if (currentX <= emptyHealth)
            {
                SceneManager.LoadScene("Defeat");
            }
        }

        if (enterEnemy)
        {
            //deal damage if enemy entered
            if (currentX > emptyHealth)
            {
                healthBarEmpty.transform.position -= new Vector3(1f * Time.deltaTime * enemiesDMG, 0, 0);
                currentX -= 1f * Time.deltaTime * enemiesDMG;
                this.gameObject.tag = "PlayerHurt";
            }

            //load defeat scene if health below 0
            if (currentX < emptyHealth)
            {
                SceneManager.LoadScene("Defeat");
            }
        }

        if (enterFood)
        {
            //restore HP 
            if (currentX + HPrestore > fullHealth)
            {
                healthBarEmpty.transform.position += new Vector3(fullHealth-currentX, 0, 0);
                currentX = fullHealth;
                enterFood = false;
                this.gameObject.tag = "PlayerHealthy";
            }
            else
            {
                healthBarEmpty.transform.position += new Vector3(HPrestore, 0, 0);
                currentX += HPrestore;
                enterFood = false;
            }
        }
    }

    //function to determine whether the player entered any obstacle/enemy/food
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            enterObstacle = true;
        }

        if (col.gameObject.tag == "Enemy")
        {
            enterEnemy = true;
        }

        if (col.gameObject.tag == "Food")
        {
            if(currentX<fullHealth)
            {
                enterFood = true;
                col.transform.gameObject.tag = "Eaten";
            }
        }

        if (col.gameObject.tag == "Food2")
        {
            if (currentX < fullHealth)
            {
                enterFood = true;
                col.gameObject.SetActive(false);
            }
        }
    }
    
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            enterObstacle = false;
        }

        if (col.gameObject.tag == "Enemy")
        {
            enterEnemy = false;
        }
    }
}
