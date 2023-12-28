using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AudioSource))]
public class Bot : MonoBehaviour
{
    public Transform player;
    public GameObject playerObj;
    private NavMeshAgent navMeshAgent;
    private AudioSource audioSource;
    private bool canPlayAudio = true;

    public bool stop = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        if (!stop && player != null)
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
        if (collision.gameObject.CompareTag("Player") && canPlayAudio)
        {
            StartCoroutine(PlayAudioWithCooldown());
        }
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

    IEnumerator PlayAudioWithCooldown()
    {
        canPlayAudio = false;
        audioSource.Play();
        playerObj.GetComponent<HitPoints>().hp -= 20;
        // Wait for 2 seconds before allowing audio to be played again
        yield return new WaitForSeconds(2.0f);

        canPlayAudio = true;
    }
}
