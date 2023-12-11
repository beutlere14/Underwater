using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class PlayerController : Controller
{
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;
    public KeyCode shootKey;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        // if we have a game manager
        if(GameManager.instance != null)
        {
            //Adding istelf to the player list, when the player enters the scene
            if (GameManager.instance.players != null)
            {
                GameManager.instance.players.Add(this);
            }
        }
    }


    public void OnDestroy()
    {
        // if we have a game manager
        if (GameManager.instance != null)
        {
            //player takes itself out of player list when it exits the game
            if (GameManager.instance.players != null)
            {
                GameManager.instance.players.Remove(this);
            }
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        ProcessInputs();
    }

    public void ProcessInputs()
    {
        if (Input.GetKey(moveForwardKey))
        {
            pawn.MoveForward();
        }

        if(Input.GetKey(moveBackwardKey))
        {
            pawn.MoveBackward();
        }

        if (Input.GetKey(rotateClockwiseKey))
        {
            pawn.RotateClockwise();
        }

        if( Input.GetKey(rotateCounterClockwiseKey)) 
        {
            pawn.RotateCounterClockwise();
        }

        if (Input.GetKeyDown(shootKey))
        {
            pawn.Shoot();
        }
    }
}
