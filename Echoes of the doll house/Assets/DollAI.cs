using UnityEngine;
using UnityEngine.AI;

public class DollAI : MonoBehaviour
{
    public Transform player; 
    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        agent.SetDestination(player.position);

        if (distance > 2f)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isAttacking", false);
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", true);
        }
    }
}
