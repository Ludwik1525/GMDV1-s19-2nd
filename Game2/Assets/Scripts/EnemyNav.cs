using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyNav : MonoBehaviour {


public  Transform playerPos,enemyPosition;

public  Vector3 enemyPositionVec3, playerPositionVec3;

public  float distance, timeOut, destinationTime;

private  NavMeshAgent navMeshAgent;

public Rigidbody rb;
public Animator anim;




    void Start()
    {	
			
		anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
	
        navMeshAgent = GetComponent<NavMeshAgent>();
		navMeshAgent.destination = new Vector3(Random.Range(-1f,1f),0,Random.Range(-1f,1f));
		
		anim.Play("crippledWalk");
		destinationTime = 250;
	
    }
	
	// Update is called once per frame
	 void Update () {
		
		if(isClose()){
			Chase();
			Hit();
		} else{
			Roam();
			anim.SetBool("isClose", false);
			
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
		
		if(timeOut >= 10000) {
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
			anim.SetBool("isClose", true);
			
		}else {
			anim.Play("crippledWalk");
		}
	}

	private Vector3 MakeRandomVector(){		
		timeOut++;
		Debug.Log(timeOut + "Timeout");
		Vector3 randomDestination = navMeshAgent.destination;
		Debug.Log(destinationTime + "destinationTime");

		if(timeOut == destinationTime){
			randomDestination = new Vector3(Random.Range(-1f,1f),0,Random.Range(-1f,1f));
			Debug.Log(randomDestination + "New dest");
			destinationTime+= 250;
		}
		Debug.Log(randomDestination + "New dest");
		return randomDestination;
	}

	public float getDistance(){
		enemyPositionVec3 = enemyPosition.position;
		 playerPositionVec3 = playerPos.position;

		
		return Vector3.Distance(enemyPositionVec3,playerPositionVec3);
	}

	
	

	
}
