using UnityEngine;
using UnityEngine.AI;

public class ChaseNPC : MonoBehaviour
{
    public float patrolRadius = 20f;
    public Transform player;

    private NavMeshAgent navMeshAgent;
    private Vector3 patrolTarget;

    public float detectionRadius = 30f;
    private Vector3 originalPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        // SetNewPatrolTarget();

        if (player == null) {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    /*void SetNewPatrolTarget()
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
        randomDirection += transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, patrolRadius, -1);
        patrolTarget = navHit.position;
    }*/

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(patrolTarget);

        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            navMeshAgent.SetDestination(player.position);
            // SetNewPatrolTarget();
        }

        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= detectionRadius) {
            navMeshAgent.SetDestination(player.position);
        }
    }
}
