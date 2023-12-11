using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMaker : MonoBehaviour
{
    //Will be a sesory amount based on how fast the character is moving
    public float volumeDistance;

    // Variable to hold the Rigidbody Component
    private Rigidbody rb;


    // Start is called before the first frame update
    public void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        checkNoise();
        //Debug.Log("Noise is " +  volumeDistance);
    }

    public void checkNoise()
    {
        //This should only work if the rigidbody is moving
        if (rb.velocity.magnitude > 0)
        {
            //sets volumeDistance to velocity
            volumeDistance = 100;
        }
        else
        {
            volumeDistance = 0;
        }
    }
}
