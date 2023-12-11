using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : Shooter
{
    public Transform firepointTransform;

    public float fireRate;
    float nextFire; 

    // Start is called before the first frame update
    public override void Start()
    {

    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    public override void Shoot(GameObject shellPrefab, float fireForce, float damageDone, float lifespan)
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
        
        #region Shooting
        // Instantiate the projectile
        GameObject newShell = Instantiate(shellPrefab, firepointTransform.position, firepointTransform.rotation);

        #region Modify the DamageOnHit component
        // Get the DamageOnHit component
        DamageOnHit doh = newShell.GetComponent<DamageOnHit>();

        //If it has one
        if (doh != null)
        {
            //set the damageDone to the value passed in
            doh.damageDone = damageDone;

            // set the owner to this pawn
            doh.owner = this.GetComponent<Pawn>();
        }
        #endregion

        #region Launch the rigidbody forward
        //Get the rigidbody 
        Rigidbody rb = newShell.GetComponent<Rigidbody>();

        // if it has a rigidbody
        if (rb != null)
        {
            rb.AddForce(firepointTransform.forward * fireForce);
        }
        #endregion

        //Destroy it after a set time.
        Destroy(newShell, lifespan);
        #endregion
        }
    }
}
