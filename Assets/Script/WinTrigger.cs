using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    //scene name we want to open
    public string sceneName;


    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.LogWarning("WinTheGame");


            Destroy(gameObject);
            SceneManager.LoadScene(sceneName);
        }
    }
}
