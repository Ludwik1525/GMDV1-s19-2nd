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
private int seconds;





		void Awake(){
			anim = GetComponentInChildren<Animator>();
      rb = GetComponent<Rigidbody>();
			anim.SetBool("isClose", false);
			anim.SetBool("noDest", true);
			anim.Play("Idle");
		}
    void Start()
    {			
    navMeshAgent = GetComponent<NavMeshAgent>();
		seconds = 0;		
	
    }
	
	// Update is called once per frame
	 void Update () {
		
		if(isClose()){
			Chase();
			
		} else{
			Roam();
			
		}				
		}
	private  bool isClose(){
	
		if(getDistance() <= 10){
			
			return true;
		}
		anim.SetBool("isClose", false);

		return false;

	}
	private  void Chase(){
		navMeshAgent.destination = playerPos.position;
		anim.SetBool("noDest", false);

		if(getDistance() <= 4){

			anim.SetBool("isClose", true);
			anim.Play("Hitting1");		
		}
		else {

			anim.Play("crippledWalk");
			anim.SetBool("isClose", false);
		}
	}
	private void Roam(){
		//indsæt wait her
			
			if(seconds<1){
				StartCoroutine(NewDestinationCountdown());		
				print("starting routine");
			}	
		
	}
	

	public float getDistance(){
		enemyPositionVec3 = enemyPosition.position;
		 playerPositionVec3 = playerPos.position;

		
		return Vector3.Distance(enemyPositionVec3,playerPositionVec3);
	}

	private IEnumerator NewDestinationCountdown()
	{	
		while(true){

				seconds++;		
			yield return new WaitForSeconds(1);
				if(seconds == 15){
					navMeshAgent.destination = new Vector3(Random.Range(-1f,1f),0,Random.Range(-1f,1f));
					anim.SetBool("noDest", false);					
					seconds = seconds * 0;					
					StopCoroutine(NewDestinationCountdown());
				}
		}
	}
	

	
}
