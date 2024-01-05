using UnityEngine;
using UnityEngine.UI;

public class Altın : MonoBehaviour
{
    public AudioClip coinSound;  // Ses dosyasını buraya sürükleyip bırakın
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Eğer karakter objenizde AudioSource bileşeni yoksa, ekleyin
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }


    void OnCollisionEnter(Collision c)
    {   if (c.gameObject.tag =="Player")
        {
            topcontrol.skor++;
            if (coinSound != null)
            {
                audioSource.PlayOneShot(coinSound);
            }

        }

        StartCoroutine(DestroyCoin(gameObject));

    }

    private System.Collections.IEnumerator DestroyCoin(GameObject coin)
    {
        
        yield return new WaitForSeconds(0.1f);
        Destroy(coin);
    }


    void Update()
    {
        // Update kodları buraya eklenebilir.
    }
}
