using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyNav : MonoBehaviour {


public  Transform playerPos,enemyPosition;

public  Vector3 enemyPositionVec3, playerPositionVec3;

public  float distance, timeOut;

private  NavMeshAgent navMeshAgent;

public Rigidbody rb;
public Animator anim;

void Awake()
	{
	}

    void Start()
    {		
		anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
		anim.SetBool("isIdle", true);
        navMeshAgent = GetComponent<NavMeshAgent>();
		navMeshAgent.destination = new Vector3(Random.Range(1f,10f),0,Random.Range(1f,10f));
		anim.SetBool("isIdle", false);
		anim.Play("crippledWalk");
    }
	
	// Update is called once per frame
	 void Update () {
		
		if(isClose()){
			Chase();
		} else{
			Roam();
		}		
			
		}
	private  void Chase(){
		navMeshAgent.destination = playerPos.position;
	}

	private  bool isClose(){
	
		if(getDistance() <= 5){
			return true;
		}

		return false;

	}

	private  void Roam(){
		
		if(timeOut >= 1000) {
			Debug.Log("Going for the kill now");
			Chase();						
		} else {
			navMeshAgent.destination = MakeRandomVector();
		}
		
	}

	public void Hit(){
		float close = getDistance();
		if(close <= 1f){
			anim.Play("Hitting1");
		}
	}

	private Vector3 MakeRandomVector(){
		timeOut++;
		Debug.Log(timeOut + "Timeout");
		Vector3 randomDestination = navMeshAgent.destination;

		if(timeOut == 250){
			randomDestination = new Vector3(Random.Range(1f,10f),0,Random.Range(1f,10f));
		}else if( timeOut == 500){
			randomDestination = new Vector3(Random.Range(1f,10f),0,Random.Range(1f,10f));
		}
		return randomDestination;
	}

	public float getDistance(){
		enemyPositionVec3 = enemyPosition.position;
		 playerPositionVec3 = playerPos.position;

		
		return Vector3.Distance(enemyPositionVec3,playerPositionVec3);
	}
	

	
}
