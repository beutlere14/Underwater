using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSound : MonoBehaviour
{

    public AudioSource m_AudioSource;
    public AudioClip explosionClip;



    // Start is called before the first frame update
    void Start()
    {

        m_AudioSource.clip = explosionClip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
