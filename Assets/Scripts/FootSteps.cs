using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F : MonoBehaviour
{
    public float moveSpeed = 5f; // Karakterin hareket h�z�
    private bool isMoving = false; // Karakterin hareket etti�ini kontrol etmek i�in kullan�lan flag

    private AudioSource audioSource; // Ses kayna��

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Hareket tu�lar�na bas�ld���nda
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement);
        movement.Normalize(); // Hareket vekt�r�n� normalize et

        // E�er karakter hareket ediyorsa
        if (movement.magnitude > 0)
        {
            isMoving = true;
            transform.Translate(movement * moveSpeed * Time.deltaTime);
        }
        else
        {
            isMoving = false;
        }

        // Sadece karakter hareket etti�inde
        if (isMoving)
        {
            // Ad�m sesini �al
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
