
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.UI;
public class HealthBar: MonoBehaviour
    {
    public Slider healthBar; 
    public Health playerHealth; 
    
    private void Start()
    {
       
    }
   

    public void Update()
    {
        //finding the healthvalue
        if (playerHealth == null)
        {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        }

        //Damage it if it has a Health component
        if (playerHealth != null)
        {
            if (healthBar != null)
            {
              //  healthBar = GetComponent<Slider>();
                healthBar.maxValue = playerHealth.GetComponent<Health>().maxHealth;
                healthBar.value = playerHealth.GetComponent<Health>().currentHealth;
            }
        }
        
       
    }
}
