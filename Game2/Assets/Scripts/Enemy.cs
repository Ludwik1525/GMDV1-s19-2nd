using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyNav2 : MonoBehaviour
{

    public Transform playerPos, enemyPosition;
    private Vector3 enemyPositionVec3, playerPositionVec3;
    private float distance, timeOut, destinationTime;
    private NavMeshAgent navMeshAgent;
    public Rigidbody rb;
    public Animator anim;

    private int chaseDistance;
    public int chaseDistanceDay;
    public int chaseDistanceNight;
    public float speedDay;
    public float speedNight;

    private Vector3 curPos, lastPos;

    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;

    public Light lt;

    public float distancea;

    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lt.gameObject.transform.rotation.eulerAngles.x > 175)
        {
            this.chaseDistance = this.chaseDistanceNight;
            this.agent.speed = this.speedNight;
        }
        else
        {
            this.chaseDistance = this.chaseDistanceDay;
            this.agent.speed = this.speedDay;
        }

        curPos = this.enemyPosition.position;
        if (curPos == lastPos)
        {
            this.anim.Play("Idle");
        }
        else if (this.getDistance() > 3)
        {
            this.anim.Play("crippledWalk");
        }
        lastPos = curPos;

        if (this.getDistance() < this.chaseDistance)
        {
            navMeshAgent.destination = playerPos.position;
            if (this.getDistance() < 3)
            {
                this.anim.Play("Hitting1");
            }
            else
            {
                this.anim.Play(("crippledWalk"));
            }
        }
        else
        {
            timer += Time.deltaTime;

            if (timer >= wanderTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;
            }
        }
        

        distancea = this.getDistance();
    }

    public float getDistance()
    {
        enemyPositionVec3 = enemyPosition.position;
        playerPositionVec3 = playerPos.position;

        return Vector3.Distance(enemyPositionVec3, playerPositionVec3);
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

}
