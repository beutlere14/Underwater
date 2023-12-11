using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    #region Varibles
    /// <summary>
    /// The static instance of this class - there can only be one.
    /// </summary>
    public static GameManager instance;

    public List<PlayerController> players;

    public static bool inStartingArea;

    public bool multiplayer;
    //Prefabs
    public GameObject playerControllerPrefab;
    public GameObject playerTwoControllerPrefab;
    public GameObject tankPawnPrefab;
    public Transform playerSpawnTransform;
    public Transform playerTwoSpawnTransform;
    public GameObject mapSpawner;

    //multiplayer objects
    public GameObject tankPawnPlayerMultiPrefab;
    public GameObject tankPawnPlayerMultiTwoPrefab;

    //For High Score, Current score, and number of lives
    public float highScore = 0;
    public float killScore = 0;
    public float lives;

    #endregion Varibles

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        players = new List<PlayerController>();
    }


    private void Start()
    {
        // SpawnPlayer();
    }


    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Main" || SceneManager.GetActiveScene().name == "MuliplayerTest")
        {
            if (players.Count == 0)
            {
              
                    SpawnPlayer();

                if (multiplayer == true)
                {
                    SpawnPlayerTwo();
                }

            }
        }
        if (killScore > highScore)
        {
            highScore = killScore;
        }
    }


    public void SpawnPlayer()
    {
        if (multiplayer != true)
        {
            // Spawn player controller at (0,0,0) with no rotation
            GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity);

            // Spawn the pawn and connect it to the controller
            GameObject newPawnObj = Instantiate(tankPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation);

            //Get the PlayerController component and Pawn component
            Controller newController = newPlayerObj.GetComponent<Controller>();
            Pawn newPawn = newPawnObj.GetComponent<Pawn>();

            // Hook them up
            newController.pawn = newPawn;
        }


        if (multiplayer == true)
        {
            // Spawn player controller at (0,0,0) with no rotation
            GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity);

            // Spawn the pawn and connect it to the controller
            GameObject newPawnObj = Instantiate(tankPawnPlayerMultiPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation);

            //Get the PlayerController component and Pawn component
            Controller newController = newPlayerObj.GetComponent<Controller>();
            Pawn newPawn = newPawnObj.GetComponent<Pawn>();

            // Hook them up
            newController.pawn = newPawn;

            this.lives = 6;
        }



    }

    public void SpawnPlayerTwo()
    {
        // Spawn player controller at (0,0,0) with no rotation
        GameObject newPlayerObj = Instantiate(playerTwoControllerPrefab, Vector3.zero, Quaternion.identity);

        // Spawn the pawn and connect it to the controller
        GameObject newPawnObj = Instantiate(tankPawnPlayerMultiTwoPrefab, playerTwoSpawnTransform.position, playerTwoSpawnTransform.rotation);

        //Get the PlayerController component and Pawn component
        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        // Hook them up
        newController.pawn = newPawn;
        if (newPlayerObj != null)
        {
            if (GetComponent<Camera>() != null)
            {
                newPawnObj.GetComponent<Camera>().depth = 0;
            }
        }

        lives = 6;


    }
    public void reload()
    {
        //The old method of reload
        //   if (mapSpawner != null)
        // {

        // Instantiate(mapSpawner, Vector3.zero, Quaternion.identity);       
        //}

        SpawnPlayer();

    }






    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inStartingArea = false;
           


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
        inStartingArea = true;

        }
    }

    public void destroyGameManager()
    {
        Destroy(gameObject);
    }

}
