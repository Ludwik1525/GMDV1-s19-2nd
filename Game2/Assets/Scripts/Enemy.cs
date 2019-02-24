using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NewBehaviourScript : MonoBehaviour {
public Transform playerPos;
public float hp;
public Rigidbody rb;

    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
		hp = 30;
    }
	
	// Update is called once per frame
	void Update () {

        navMeshAgent.destination = playerPos.position;
		hp--;
		if(hp <= 0){
			
		}

	}

	
}
