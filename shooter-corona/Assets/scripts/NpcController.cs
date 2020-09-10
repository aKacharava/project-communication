using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    //Variables

    public float lookRadius = 10f;
    public float infectRadius = 3f;
    public float wanderRadius;
    public float wanderTimer;
    public float infectTimer;
    public bool masked;
    public Color currentColor;

    private float timer;
    private bool attacking;
    private Transform targetTransform;
    private NavMeshAgent agent;
    private PlayerHealth targetHealth;
     

    //Methods

    void Start()
    {
        targetHealth = PlayerManager.instance.player.GetComponent<PlayerHealth>();
        targetTransform = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        masked = false;
        attacking = false;
    }
        
    void Update()
    {
        timer += Time.deltaTime;
        float distance = Vector3.Distance(targetTransform.position, transform.position);

        if (distance <= lookRadius && !masked)
        {
            //follow target
            agent.SetDestination(targetTransform.position);
            attacking = true;

            if (distance <= agent.stoppingDistance)
            {
                //face target
                FaceTarget();
            }
        }
        else attacking = false;
        if (timer >= wanderTimer && !attacking)
        {
            //wander
            Vector3 newPosition = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPosition);
            timer = 0;
        }
        if (timer >= infectTimer && distance <= infectRadius && !masked)
        {
            //infect target
            InfectTarget();
            timer = 0;
        }

        currentColor = gameObject.GetComponentInChildren<Renderer>().material.color;

        if (currentColor == new Color(0, 1, 0, 1))
        {
            //masked if material on children is green
            masked = true;
        }
    }

    private void FaceTarget ()
    {
        Vector3 direction = (targetTransform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    //draw lookRadius and infectRadius
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, infectRadius);
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;

        randomDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;
    }

    public void InfectTarget()
    {
        targetHealth.DamagePlayer(targetHealth.infectionRate);
    }
}
