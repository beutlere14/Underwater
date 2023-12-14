using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScubaShooter : Shooter
{
    //for having a game object dissapear and reappear
    public GameObject harpoonInPlace;
    public GameObject[] harpoonPieces;
    public Boolean harpoonGone;
   // public float i;


    public Transform firepointTransform;

    public float fireRate;
    float nextFire; 

    // Start is called before the first frame update
    public override void Start()
    {
      //  Instantiate(harpoonInPlace, firepointTransform.position, firepointTransform.rotation);
    }

    // Update is called once per frame
    public override void Update()
    {
        // if you have not shot the harpoon

        if (harpoonPieces != null)
        {
            if (harpoonGone == false)
            {
                //Harpoon is visible as it is not gone
              //  harpoonInPlace.GetComponentInChildren<Renderer>().enabled = true;
              
                foreach (var piece in harpoonPieces)
                {
                   
                    harpoonPieces[0].GetComponentInChildren<Renderer>().enabled = true;
                    harpoonPieces[1].GetComponentInChildren<Renderer>().enabled = true;
                    harpoonPieces[2].GetComponentInChildren<Renderer>().enabled = true;
                    harpoonPieces[3].GetComponentInChildren<Renderer>().enabled = true;
                    harpoonPieces[4].GetComponentInChildren<Renderer>().enabled = true;
                    harpoonPieces[5].GetComponentInChildren<Renderer>().enabled = true;
                }
               
            }
            else
            {
                //harpoon is gone and no longer visble
                // harpoonInPlace.GetComponentInChildren<Renderer>().enabled = false;
                harpoonPieces[0].GetComponentInChildren<Renderer>().enabled = false;
                harpoonPieces[1].GetComponentInChildren<Renderer>().enabled = false;
                harpoonPieces[2].GetComponentInChildren<Renderer>().enabled = false;
                harpoonPieces[3].GetComponentInChildren<Renderer>().enabled = false;
                harpoonPieces[4].GetComponentInChildren<Renderer>().enabled = false;
                harpoonPieces[5].GetComponentInChildren<Renderer>().enabled = false;
            }
        }
        
    }

    public override void Shoot(GameObject shellPrefab, float fireForce, float damageDone, float lifespan)
    {
        if (Time.time > nextFire)
        {

            nextFire = Time.time + fireRate;
            harpoonGone = true;

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
            Invoke("harpoonTrue", lifespan);
        #endregion
        }
    }

    public void harpoonTrue()
    {
        harpoonGone = false;
    }
}
