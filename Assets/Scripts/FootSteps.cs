using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F : MonoBehaviour
{
    public float moveSpeed = 5f; // Karakterin hareket hýzý
    private bool isMoving = false; // Karakterin hareket ettiðini kontrol etmek için kullanýlan flag

    private AudioSource audioSource; // Ses kaynaðý

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Hareket tuþlarýna basýldýðýnda
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement);
        movement.Normalize(); // Hareket vektörünü normalize et

        // Eðer karakter hareket ediyorsa
        if (movement.magnitude > 0)
        {
            isMoving = true;
            transform.Translate(movement * moveSpeed * Time.deltaTime);
        }
        else
        {
            isMoving = false;
        }

        // Sadece karakter hareket ettiðinde
        if (isMoving)
        {
            // Adým sesini çal
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
