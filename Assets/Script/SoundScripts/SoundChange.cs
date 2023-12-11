using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundChange : MonoBehaviour
{
    //This code is for Audio Sorce on GameManager
    public AudioSource m_AudioSource;
    public AudioClip main_Clip;
    public AudioClip mainMenu_Clip;
    public AudioClip gameOver_Clip;

    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Main" || SceneManager.GetActiveScene().name == "MuliplayerTest")
        {
            // if not already playing main clip
            if (m_AudioSource.clip != main_Clip)
            {
                m_AudioSource.clip = main_Clip;
                m_AudioSource.Play();
            }
        }

        if (SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "Options")
        {
            // if not already plaing mainMenu Clip
            if (m_AudioSource.clip != mainMenu_Clip)
            {
                 m_AudioSource.clip = mainMenu_Clip;
                 m_AudioSource.Play();
            }
           
        }
        if(SceneManager.GetActiveScene().name == "LoadingScene")
        {
            // if not already playing gameOver Clip
            if (m_AudioSource.clip != gameOver_Clip)
            {
                  m_AudioSource.clip = gameOver_Clip;
                 m_AudioSource.Play();
            }
          
        }
    }
}
