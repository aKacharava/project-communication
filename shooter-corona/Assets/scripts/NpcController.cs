using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    //Variables

    public float lookRadius = 10f;
    public float infectPlayerRadius = 3f;
    public float infectNPCsRadius = 2.5f;
    public float wanderRadius;
    public float wanderTimer;
    public float infectPlayerTimer;
    public bool masked;
    public bool infected;
    public Color currentColor;

    private float timer;
    private bool attacking;

    private List<GameObject> NPCs = new List<GameObject>();
    private Transform targetTransform;
    private NavMeshAgent agent;
    private PlayerHealth targetHealth;

    private static List<NpcController> instances = new List<NpcController> { };
    //Method

    void Start()
    {
        targetHealth = PlayerManager.instance.player.GetComponent<PlayerHealth>();
        targetTransform = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        masked = false;
        attacking = false;

        NpcController.instances.Add(this);
    }
        
    void Update()
    {
        timer += Time.deltaTime;



        if (infected)
        {
            if (!masked)
            {
                gameObject.GetComponentInChildren<Renderer>().material.color = Color.red;
            }

            foreach (var npc in NpcController.instances)
            {
                if (npc == null)
                    continue;
                float distanceToNpc = Vector3.Distance(transform.position, npc.transform.position);

                if (distanceToNpc <= infectNPCsRadius && !npc.infected && !npc.masked && !masked)
                {
                    npc.infected = true;
                }
            }

        }



        float distanceToTarget = Vector3.Distance(targetTransform.position, transform.position);

        if (distanceToTarget <= lookRadius && !masked && infected)
        {
            //follow target
            agent.SetDestination(targetTransform.position);
            attacking = true;

            if (distanceToTarget <= agent.stoppingDistance)
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
        //infect by healthy
        if (timer >= infectPlayerTimer && distanceToTarget <= infectPlayerRadius && !masked && !infected)
        {
            //infect target
            InfectTarget(targetHealth.infectByHealthyRate);
            timer = 0;
        }
        //infect by sick
        if (timer >= infectPlayerTimer && distanceToTarget <= infectPlayerRadius && !masked && infected)
        {
            //infect target
            InfectTarget(targetHealth.infectBySickRate);
            timer = 0;
        }

        //currentColor = gameObject.GetComponentInChildren<Renderer>().material.color;

        //if (currentColor == new Color(0, 1, 0, 1))
        //{
        //    //masked if material on children is green
        //    masked = true;
        //}
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
        Gizmos.DrawWireSphere(transform.position, infectPlayerRadius);
        Gizmos.color = Color.green;
        if(infected)
        {
            Gizmos.DrawWireSphere(transform.position, infectNPCsRadius);
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;

        randomDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;
    }

    public void InfectTarget(float infectionRate)
    {
        targetHealth.DamagePlayer(infectionRate);
    }
}
