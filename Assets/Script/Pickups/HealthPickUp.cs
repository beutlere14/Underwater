using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : Pickup
{
    public HealthPowerup powerup;

    //Points to add to score
    public float bonusPoints = 50;
    //to interact with game manager to add score
    public GameManager gameManager;

    //Allows the explosion effect to be spawned
    public Transform whatToSpawn;

    public override void OnTriggerEnter(Collider other)
    {
        // variable to store other object's PowerupController - if it has one
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();

        // If the other object has a PowerupController
        if (powerupManager != null)
        {
            // Add the powerup
            powerupManager.Add(powerup);

            //in case what to spawn equals nothing, so it doesn't get stuck here.
            if (whatToSpawn != null)
            {
                //Spawns Explosion
                Instantiate(whatToSpawn, transform.position, transform.rotation);
            }

            //Adding score only if player is the one to pick it up
            if (other.CompareTag("Player"))
            {
                if (gameManager != null)
                {
                    gameManager.killScore = gameManager.killScore + bonusPoints;
                }
            }

            // Destroy this pickup
            Destroy(gameObject);

        }
    }
}
