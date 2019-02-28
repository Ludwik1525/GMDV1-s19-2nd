using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefeatCounter : MonoBehaviour {

    void Start()
    {
        StartCoroutine(Counter(40, GetComponent<Text>()));
    }


    public IEnumerator Counter(float t, Text i)
    {
        while (int.Parse(i.text) > 0)
        {
            i.text = "" + (int.Parse(i.text)-1);
            yield return new WaitForSeconds(1);
        }
    }
}
