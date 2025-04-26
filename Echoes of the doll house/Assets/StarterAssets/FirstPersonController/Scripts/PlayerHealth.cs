//written by Tariro Grace
using UnityEngine;
using UnityEngine.SceneManagement; // Only if you want to restart scene on death

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("Player took damage! Current health: " + currentHealth);

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Died!");

        // Example: Restart the scene when dead
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

