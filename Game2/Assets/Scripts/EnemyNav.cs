using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyNav : MonoBehaviour {


public  Transform playerPos,enemyPosition;

private  NavMeshAgent navMeshAgent;

public Rigidbody rb;
public Animator anim;
private int seconds;
public int chaseDistance;


		
    void Start()
    {			
			anim = GetComponentInChildren<Animator>();
      rb = GetComponent<Rigidbody>();
			anim.SetBool("isClose", false);
			anim.SetBool("noDest", true);
			anim.Play("Idle");
    	navMeshAgent = GetComponent<NavMeshAgent>();
			seconds = 0;
			chaseDistance = 50;		
	
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
	
		if(getDistance() <= chaseDistance){
			
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

			Roam();
		}
	}
	private void Roam(){
		//indsæt wait her
			
			if(seconds<1){
				StartCoroutine(NewDestinationCountdown());				
			}	
		
	}	

	public float getDistance(){
		
		return Vector3.Distance(enemyPosition.position,playerPos.position);
	}

	private IEnumerator NewDestinationCountdown()
	{	
		while(true){

				seconds++;		
			yield return new WaitForSeconds(1);
				if(seconds == 5){
					navMeshAgent.destination = new Vector3(Random.Range(-1f,1f),0f,Random.Range(-1f,1f)).normalized * 20;
					anim.Play("crippledWalk");
					anim.SetBool("noDest", false);					
					seconds = seconds * 0;					
					StopCoroutine(NewDestinationCountdown());
				}
		}
	}
	

	
}
