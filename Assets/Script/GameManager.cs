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


    public bool multiplayer;
    //Prefabs
    public GameObject playerControllerPrefab;
    public GameObject scubaPawnPrefab;
    public Transform playerSpawnTransform;



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

              

            }
        }
       
    }


    public void SpawnPlayer()
    {
        if (multiplayer != true)
        {
            // Spawn player controller at (0,0,0) with no rotation
            GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity);

            // Spawn the pawn and connect it to the controller
            GameObject newPawnObj = Instantiate(scubaPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation);

            //Get the PlayerController component and Pawn component
            Controller newController = newPlayerObj.GetComponent<Controller>();
            Pawn newPawn = newPawnObj.GetComponent<Pawn>();

            // Hook them up
            newController.pawn = newPawn;
        }



    }





}
