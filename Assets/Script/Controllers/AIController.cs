using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AIController : Controller
{
    #region Varibles
    public enum AIState { Idle, Guard, Chase, Flee, Patrol, Attack, BacktoPost };

    /// <summary>
    /// The current State of this FSM.
    /// </summary>
    public AIState currentState;

    private float lastStateChangeTime;

    public GameObject target;

    public float hearingDistance;

    public float fieldOfView;
    #endregion
    // Start is called before the first frame update
    public override void Start()
    {
        //run the parents base
        base.Start();

        TargetPlayerOne();
       // TargetNearestTank();
    }

    // Update is called once per frame
    public override void Update()
    {
         MakeDecisions();

        // run the parents base
        base.Update();
       

    }

  

    /// <summary>
    /// Automatically make decisions about what to do based on current conditions
    /// </summary>
    public void MakeDecisions()
    {
        //Debug.Log("Making Decisions");
        if (target == null)
        {
            Debug.Log("Retargeting");
            // TargetPlayerOne();
            TargetNearestTank();
        }
        else
        {
            //Seek(target);
            //Idle(target);
            CanHear(target);
            CanSee(target);
            //TargetNearestTank();
        }
    }
    
    //This is the one that works
    public void TargetPlayerOne()
    {
     
        Debug.Log("Attempting to Target");
        // If the GameManager exists
        if (GameManager.instance != null)
        {
            // And the array of players exists
            if (GameManager.instance.players != null)
            {
                // And there are players in it
                if (GameManager.instance.players.Count > 0)
                {
                    //Then target the gameObject of the pawn of the first player controller in the list
                    target = GameManager.instance.players[0].pawn.gameObject;

                    Debug.Log("Player Once Targeted");
                }
            }
        }
    }

    //This one accidentally targets itself since it too is a tank
    protected void TargetNearestTank()
    {
        // Get a list of all the tanks (pawns)
        Pawn[] allTanks = FindObjectsOfType<Pawn>();

        // Assume that the first tank is closest
        Pawn closestTank = allTanks[0];
        float closestTankDistance = Vector3.Distance(pawn.transform.position, closestTank.transform.position);

        // Iterate through them one at a time
        foreach (Pawn tank in allTanks)
        {
            if (tank.CompareTag("Player"))
            {
                // If this one is closer than the closest
                if (Vector3.Distance(pawn.transform.position, tank.transform.position) <= closestTankDistance)
                {
                    // It is the closest
                    closestTank = tank;
                    closestTankDistance = Vector3.Distance(pawn.transform.position, closestTank.transform.position);
                }
            }

            // Target the closest tank
            target = closestTank.gameObject;
        }
    }
    //Needs some edits once we have more working states
    public bool CanHear(GameObject target)
    {
        // Get the target's NoiseMaker
        NoiseMaker noiseMaker = target.GetComponent<NoiseMaker>();
        // If they don't have one, they can't make noise, so return false
        if (noiseMaker == null)
        {
            return false;
        }
        // If they are making 0 noise, they also can't be heard
        if (noiseMaker.volumeDistance <= 0)
        {
           
            Idle(target);
            return false;
        }
        // If they are making noise, add the volumeDistance in the noisemaker to the hearingDistance of this AI
        float totalDistance = noiseMaker.volumeDistance + hearingDistance;
        // If the distance between our pawn and target is closer than this...
        if (Vector3.Distance(pawn.transform.position, target.transform.position) <= totalDistance)
        {
            // ... then we can hear the target
            Seek(target);
            return true;
        }
        else
        {
            // Otherwise, we are too far away to hear them
            
            // Ideally this should change to some sort of patrol of moving randomly
            Idle(target);
            return false;
        }
    }


    public bool CanSee(GameObject target)
    {
        // Find the vector from the agent to the target
        Vector3 agentToTargetVector = target.transform.position - transform.position;
        // Find the angle between the direction our agent is facing (forward in local space) and the vector to the target.
        float angleToTarget = Vector3.Angle(agentToTargetVector, pawn.transform.forward);
        // if that angle is less than our field of view
        if (angleToTarget < fieldOfView)
        {
            //We are likely going to use this to figure out a shooting distance
            //Debug.Log("Can See you");
           pawn.Shoot();
            return true;
            
        }
        else
        {
            //Debug.Log("Where are you?");
            return false;
        }
    }


    public virtual void ChangeState(AIState newState) 
    {
        //Change the current state
        currentState = newState;

        //Log the time that this change happened.
       lastStateChangeTime = Time.time;
    }


    #region SeekState
    public void DoSeekState()
    {
        Seek(target);
    }

    public void Seek(Vector3 targetPosition)
    {
       //Rotate towards Target
        pawn.RotateTowards(targetPosition);

       // Debug.Log("Shuold be Rotating");

        //Move towards target
        pawn.MoveForward();
    }

    public void Seek (GameObject target)
    {
        //rotate towrds target
        Seek(target.transform.position);
    }

    public void Seek(Transform targetTransform)
    {
        Seek(target.transform.position);
    }

    public void Seek(Pawn targetPawn)
    {
        Seek(targetPawn.gameObject);
    }
    #endregion


    #region Idle
    public void DoIdleState()
    {
        Idle(target);
    }

    public virtual void Idle(Vector3 targetPosition)
    {
        //Rotate towards Target
        pawn.RotateTowards(targetPosition);
    }

    public void Idle(GameObject target)
    {
        //rotate towrds target
        Idle(target.transform.position);
    }
    #endregion



}
