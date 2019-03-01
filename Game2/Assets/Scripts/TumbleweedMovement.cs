using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleweedMovement : MonoBehaviour
{

    public float speed;
    private float nextActionTime = 0.0f;
    public float period;
    private Vector3 direction;

    void Start()
    {
        direction = new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f));
        gameObject.transform.eulerAngles += direction;
    }

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            direction = new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f));
                gameObject.transform.eulerAngles += direction;
            }
        transform.position += direction * (speed+ Random.Range(-2.0f, 6.0f)) * Time.deltaTime;
    }
}
    
