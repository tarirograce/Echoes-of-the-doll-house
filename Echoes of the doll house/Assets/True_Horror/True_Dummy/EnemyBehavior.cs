using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;  // Assign the Player in the Inspector
    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position); // Move towards the player

            // Set animation based on movement
            if (agent.velocity.magnitude > 0.1f)
            {
                animator.SetBool("isWalking", true);  // Play walking animation
            }
            else
            {
                animator.SetBool("isWalking", false); // Stop animation
            }
        }
    }
}
