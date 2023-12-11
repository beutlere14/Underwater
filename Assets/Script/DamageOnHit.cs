using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    public float damageDone;
    public Pawn owner;
    public Transform whatToSpawn;

    //Sounds
    public AudioSource m_AudioSource;
    public AudioClip spawnedSound;

    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NoHit"))
        {
            // So it doesnt hit thinks that would otherwise interupt it.
            // Namely the colloders of maps overall that trigger upon the player exiting to blow them up
        }
        else
        {
            //If the object this projectile hit has a Health component
            Health otherHealth = other.gameObject.GetComponent<Health>();

            //Damage it if it has a Health component
            if (otherHealth != null)
            {
                otherHealth.TakeDamage(damageDone, owner);
            }

            //Destroy the projectile when it hits anything, even if it didn't do damage
            Instantiate(whatToSpawn, transform.position, transform.rotation);

            //Spawing sound if there is one to spawn
            if (spawnedSound != null)
            {
                m_AudioSource.clip = spawnedSound;
            }
            Destroy(gameObject);
        }
    }
}
