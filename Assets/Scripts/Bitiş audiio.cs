using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitişAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public float stopDistance;

    public Transform karakter;
    private float defaultVolume;

    void Start()
    {
        defaultVolume=audioSource.volume;
        
        
    }
    private void Update() { 
            if(karakter==null)
        {
            return;
        } else
        {
            float dist = Vector3.Distance(transform.position, karakter.position);

            if (dist>stopDistance)
            {
                audioSource.volume = defaultVolume;
            }
            else
            {
                audioSource.volume = 0.0f;   
            }
        }
    }
}
