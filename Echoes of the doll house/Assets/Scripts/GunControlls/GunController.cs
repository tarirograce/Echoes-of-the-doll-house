//written by Tariro Grace
using UnityEngine;
using System.Collections;  

public class GunController : MonoBehaviour
{
    public Camera fpsCam;  // Reference to the FPS camera (for shooting direction)
    public float damage = 20f;  // Damage the gun deals per shot
    public float range = 50f;  // Maximum shooting distance
    public float fireRate = 0.2f;  // Time between shots
    public float reloadTime = 1.5f;  // Time to reload the gun
    public int maxAmmo = 10;  // Max ammo capacity
    private int currentAmmo;  // Current ammo count
    private float nextTimeToFire = 0f;  // Time before the next shot can be fired
    private bool isReloading = false;  // Flag for checking if the gun is reloading

    void Start()
    {
        currentAmmo = maxAmmo;  // Set the initial ammo to max ammo
    }

    void Update()
    {
        // If the gun is reloading, don't allow shooting
        if (isReloading)
            return;

        // If ammo is empty, start reloading
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());  // Start the reload process
            return;
        }

        // Check if the player pressed the fire button (usually the left mouse button)
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;  // Wait until fireRate time is passed
            Shoot();  // Call Shoot function to fire the gun
        }
    }

    // Function to handle shooting
    void Shoot()
    {
        currentAmmo--;  // Decrease ammo count after firing
        Debug.Log("Shot Fired! Ammo Left: " + currentAmmo);  // Debug log to show ammo

        // Perform a raycast to detect if the shot hits anything
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name);  // Log the name of the hit object

            // REMOVE or COMMENT OUT this block if you don't want to deal damage yet
            /*
            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);  // Apply damage to the enemy
            }
            */
        }
    }


    // Coroutine for reloading the gun
    IEnumerator Reload()
    {
        isReloading = true;  // Set reloading flag to true
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);  // Wait for the reload time
        currentAmmo = maxAmmo;  // Refill ammo to max capacity
        isReloading = false;  // Reset reloading flag
    }
}
