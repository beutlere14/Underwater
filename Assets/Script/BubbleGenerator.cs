using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGenerator : MonoBehaviour
{
    //Will be a sesory amount based on how fast the character is moving
    public GameObject bubbleTrail;
    private GameObject spawnedBubbles;

    public float time = 0.0f;
    public float timeFrame = 1f;

    // Variable to hold the Rigidbody Component
    private Rigidbody rb;


    // Start is called before the first frame update
    public void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
        bubbleRedirect();
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= timeFrame)
        {
            time = 0.0f;
            bubbleRedirect();
        }
    
    }

 

    public void bubbleRedirect()
    {
        spawnedBubbles = Instantiate(bubbleTrail, transform.position, Quaternion.identity);
    }
}
