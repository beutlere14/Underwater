
using UnityEngine;

using TMPro;

using System;

public class ScoreUpdate : MonoBehaviour
{
    public GameManager gameManager;


    //text that could be on a UI but we want it blank
    public TMP_Text b1text;

    // Start is called before the first frame update
    void Start()
    {
       

        // setting up communication with the text value to then get rid of the text
        b1text = gameObject.GetComponentInChildren<TMP_Text>(true);
        btnValue();
    }

   


    //BaseValue
    public void btnValue()
    {
        b1text.text = "0";
    }


    // Update is called once per frame
    void Update()
    {
       if (gameManager != null)
        {
            b1text.text = Convert.ToString(gameManager.killScore);
        }
    }

   
}
