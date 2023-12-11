using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public List<Powerup> powerups;
    private List<Powerup> removedPowerupQueue;
    // Start is called before the first frame update
    void Start()
    {
        powerups = new List<Powerup>();
        removedPowerupQueue = new List<Powerup>();
    }

    // Update is called once per frame
    void Update()
    {
        DecrementPowerupTimer();
    }


    private void LateUpdate()
    {
        ApplyRemovePowerupsQueue();
    }


    public void Add(Powerup powerupToAdd)
    {
        //Applying the powerup
        powerupToAdd.Apply(this);

        //saving it to the list
        powerups.Add(powerupToAdd);
    }

    public void Remove(Powerup powerupToRemove)
    {
        //Remove the powerup 
        powerupToRemove.Remove(this);

        //Remove it from the list
        removedPowerupQueue.Add(powerupToRemove);
    }

    public void DecrementPowerupTimer()
    {
        //One at a time, put each object in "powerups" into the varible "powerup" and do the loop on it
        foreach (Powerup powerup in powerups)
        {
            if (powerup.isPermanent == false)
            {
                // Subtract the time it took to draw the frame from the duration
                powerup.duration -= Time.deltaTime;

                // If time is up, we want to remove the powerup
                if (powerup.duration <= 0)
                {
                    Remove(powerup);
                }
            }
        }
    }

    private void ApplyRemovePowerupsQueue()
    {
        // Remove the queued Powerups from the applied list.
        foreach (Powerup powerup in removedPowerupQueue)
        {
            powerups.Remove(powerup);
        }

        // Reset our Temporary list.
        removedPowerupQueue.Clear();
    }
}
