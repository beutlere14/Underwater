using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreResetter : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        if (gameManager != null)
        {
            gameManager.killScore = gameManager.killScore -gameManager.killScore;
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
