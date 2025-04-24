using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public int maxHealth = 100;
    public int damage = 20;
    public float attackCooldown = 1.5f;

    Transform player;
    NavMeshAgent agent;
    Animator animator;
    int currentHealth;
    bool isDead = false;
    float lastAttackTime = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (isDead) return;

        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(player.position);

            if (agent.remainingDistance > agent.stoppingDistance)
            {
                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isWalking", false);
                FacePlayer();

                if (Time.time - lastAttackTime >= attackCooldown)
                {
                    animator.SetTrigger("Attack");
                    lastAttackTime = Time.time;

                    // You can call a function to damage the player here
                   // player.GetComponent<PlayerHealth>()?.TakeDamage(damage);
                }
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    void FacePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        animator.SetTrigger("Die");
        agent.enabled = false;
        Destroy(gameObject, 5f); // Optional: delay before removing enemy
    }
}
