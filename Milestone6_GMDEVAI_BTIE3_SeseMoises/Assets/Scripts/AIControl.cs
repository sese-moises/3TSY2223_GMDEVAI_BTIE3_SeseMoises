using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{
    public GameObject[] goals;
    NavMeshAgent agent;
    Animator animator;
    float speedMultiplier;
    float detectionRadius = 10;
    float moveRadius = 10;

    void ResetAgent()
    {
        speedMultiplier = Random.Range(0.1f, 1.5f);
        agent.speed = 2 * speedMultiplier;
        agent.angularSpeed = 120;
        animator.SetFloat("speedMultiplier", speedMultiplier);
        animator.SetTrigger("isWalking");
        agent.ResetPath();
    }

    private void Start()
    {
        goals = GameObject.FindGameObjectsWithTag("goal");
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goals[Random.Range(0, goals.Length)].transform.position);
        animator = GetComponent<Animator>();
        animator.SetTrigger("isWalking");
        animator.SetFloat("wOffset", Random.Range(0.1f, 1.0f));
        ResetAgent();
    }

    private void Update()
    {
        if (agent.remainingDistance < 1)
        {
            ResetAgent();
            agent.SetDestination(goals[Random.Range(0, goals.Length)].transform.position);
        }
    }

    public void DetectNewObstacle(int i, Vector3 location)
    {
        if (Vector3.Distance(location, transform.position) < detectionRadius)
        {
            Vector3 moveDirection = (transform.position - location).normalized;
            Vector3 newGoal = transform.position + moveDirection * moveRadius;
            if (i > 0)
            {
                newGoal = transform.position - moveDirection * moveRadius;
            }

            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath(newGoal, path);

            if (path.status != NavMeshPathStatus.PathInvalid)
            {
                agent.SetDestination(path.corners[path.corners.Length - 1]);
                animator.SetTrigger("isRunning");
                agent.speed = 10;
                agent.angularSpeed = 500;
            }
        }
    }
}
