using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
   public GameManager gameManager;
   private Transform respawnPoint;
    public float scoreBonus;
    public string gameOverLevel = "LoadingScene";


    public float currentHealth;
    public float maxHealth;


    //Allows the explosion effect to be spawned
    public Transform whatToSpawn;

    //Delay so the player can see their own explosion before they die fully
    public float deathDelay;

    //These varibles are for if you are invincible. The bool says if you are or not.
    public bool cantLoseHealth;
    //The Constant heatlh remembers what you were at when you began and keeps you there
    private float constantHealth;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        if (gameManager != null)
        {
            respawnPoint = gameManager.playerSpawnTransform.transform;
        }
    }

    private void Update()
    {
        if (cantLoseHealth == true)
        {
            InvincibleLoop();
        }
    }

    /// <summary>
    /// Subtract incoming damage from current health.
    /// </summary>
    /// <param name="amount">The amount of damage that was received.</param>
    /// <param name="source">the Pawn that fired the projectile.</param>
    public void TakeDamage(float amount, Pawn source)
    {
        currentHealth = currentHealth - amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
       // Debug.Log(source.name + " did " + amount + " damage to " + gameObject.name + ".");

        if (currentHealth <= 0)
        {
            Die(source);
        }
    }


    public void Heal(float amount, Pawn source)
    {
        currentHealth = currentHealth + amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log(source.name + " healed " + amount + " points to " + gameObject.name + ".");
    }

    public void Invincible()
    {
        
        if (cantLoseHealth == true)
        {
            //Sets the constant health to whatever your current health is when you gain invincibility.
            constantHealth = currentHealth;
        }
    }


    public void InvincibleLoop()
    {
        
        if (cantLoseHealth == true)
        {
            //Keeps your current health at the constant health you had checked when you first gained invincibility
            currentHealth = constantHealth;

            Debug.Log("Health is " + currentHealth);
        }
    }



    public void Die (Pawn source)
    {
       

        Debug.Log(source.name + " killed " + gameObject.name + ".");
        //When a tank dies it spawns an explosion and set timer for it to go off
        Explode();
        //Destroy(gameObject);
    }

    void Explode()
    {
        addKillScore();


        if (gameObject.tag == "Player")
        {
            if (respawnPoint != null)
            {
                if (gameManager != null)
                {
                    // to increment life down and load in new map
                    Invoke("mapLifeReset", .1f);
                  //  gameObject.transform.position = new Vector3(respawnPoint.position.x, respawnPoint.position.y, respawnPoint.position.z);

                }
            }
        }

        //Spawns Explosion
        Instantiate(whatToSpawn, transform.position, transform.rotation);
        //Creates a delay equal to deathDelay varible
        Invoke("TrueDead", deathDelay);
    }

    private void TrueDead()
    {
        if (gameObject.tag == "Player")
        {
           
        }

        else
        {
            //Destroys object after deathDelay has completed
            Destroy(gameObject);
        }

    }

    public void addKillScore()
    {
        if (gameManager != null)
        {
            gameManager.killScore = gameManager.killScore + scoreBonus;
            Debug.Log(gameManager.killScore);
        }
    }


    public void mapLifeReset()
    {
        if (gameManager != null)
        {

            gameManager.lives--;

            //0 lives is your last life

            if (gameManager.lives > -1)
            {



                currentHealth = maxHealth;

                //  gameManager.reload();


                Invoke("positionChange", .1f);
            }
            else
            {
              //  gameManager.destroyGameManager();
                SceneManager.LoadScene(gameOverLevel);
            }
        



        }
    }


    public void positionChange()
    {
        gameObject.transform.position = new Vector3(respawnPoint.position.x, respawnPoint.position.y, respawnPoint.position.z);
    }


 
  

}
