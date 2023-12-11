using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthPowerup : Powerup
{
    public float healthToAdd;

    public override void Apply(PowerupManager target)
    {
        // Apply Health Changes
        Health targetHealth = target.GetComponent<Health>();

        if (targetHealth != null)
        {
            // The Second parameter is the pawn that caused the healing - they healed themselves
            targetHealth.Heal(healthToAdd, target.GetComponent<Pawn>());
        }
    }

    public override void Remove(PowerupManager target)
    {
        Debug.LogWarning("This should not be running. Health powerup should not be getting removed!");
    }
}
