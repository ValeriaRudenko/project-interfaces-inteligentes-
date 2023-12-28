using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class BotFollowPlayer : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (player == null)
        {
            Debug.LogError("Player not assigned to the bot!");
        }
        else
        {
            navMeshAgent.SetDestination(player.position);
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Update the destination to follow the player
            navMeshAgent.SetDestination(player.position);

            // Rotate towards the player
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5.0f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the bot collided with an obstacle
        if (!collision.gameObject.CompareTag("Floor"))
        {
            // Calculate a new direction to navigate around the obstacle
            Vector3 randomDirection = Random.insideUnitSphere * 10.0f;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, 10.0f, NavMesh.AllAreas);

            // Set the new destination for the NavMeshAgent
            navMeshAgent.SetDestination(hit.position);
        }
    }
}
