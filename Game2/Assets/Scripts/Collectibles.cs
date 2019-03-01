using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Collectibles : MonoBehaviour
{

    public AudioClip collect;
    public AudioSource source;
    public Text current;
    private int counter=0;
    public int max;

    void Start()
    {
    }
    
    void Update()
    {
        if (counter == max)
        {
            SceneManager.LoadScene("VictoryScene");
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="Collectible")
        {
            col.gameObject.SetActive(false);
            source.PlayOneShot(collect);
            counter++;
            current.text = "" + counter;
        }
    }
}
