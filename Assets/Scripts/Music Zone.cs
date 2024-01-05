using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicZone : MonoBehaviour
{
    public AudioSource audioSource;
    public float fadeTime;
    private float targetVolume;

    // Start is called before the first frame update
    void Start()
    {
        targetVolume = 2.0f;
        audioSource.volume = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = Mathf.MoveTowards(audioSource.volume, targetVolume, (1.0f / fadeTime) * Time.deltaTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetVolume=2.0f;
        }
    }
    private void OnTriggerExist(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            targetVolume = 2.0f;
        }
    }
}
