using UnityEngine;
using UnityEngine.AI;

public class PassiveNPC : MonoBehaviour
{
    public float patrolRadius = 20f;

    private NavMeshAgent navMeshAgent;
    private Vector3 patrolTarget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetNewPatrolTarget();
    }

    void SetNewPatrolTarget()
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
        randomDirection += transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, patrolRadius, -1);
        patrolTarget = navHit.position;
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(patrolTarget);

        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            SetNewPatrolTarget();
        }
    }
}
