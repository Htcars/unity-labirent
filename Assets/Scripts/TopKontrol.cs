
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class topcontrol : MonoBehaviour
{
    public Button btn;
    private Rigidbody rb;
    public float Hiz = 3f;
    public float zamanSayaci = 10;
    public float canSayaci = 2;
    public Text zamanText, canText, durum;
    bool oyunDevam = true;
    bool oyunTamam = false;
    //public static Button restart;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (zamanSayaci > 0 && oyunDevam && !oyunTamam)
        {
            zamanSayaci -= Time.deltaTime;
            zamanText.text = Mathf.Max(0, (int)zamanSayaci).ToString();
        }
        else
        {
            if (!oyunTamam)
            {
                durum.text = "Oyun tamamlanamadý";
                btn.gameObject.SetActive(true);
            }
            {
                OyunuKaybet();
              //  restart.SetActive(true);
            }
            zamanText.text = "0";
        }

        canText.text = Mathf.Max(0, (int)canSayaci).ToString();
        if (canSayaci <= 0)
        {
            OyunuKaybet();
        }
    }

    void FixedUpdate()
    {
        if (oyunDevam && !oyunTamam)
        {
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            Vector3 kuvvet = new Vector3(-dikey, 0, -yatay);
            rb.AddForce(kuvvet * Hiz);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        string ObjIsmi = other.gameObject.name;
        if (ObjIsmi.Equals("Bitis"))
        {
            oyunTamam = true;
            durum.text = "Oyun Tamamlandý. Tebrikler!";
            btn.gameObject.SetActive(true);
            OyunuKazandiniz();
            //restart.SetActive(true);
        }
        else if (!ObjIsmi.Equals("Zemin") && !ObjIsmi.Equals("Labirentzemin") && !ObjIsmi.Equals("Baslangic") && !ObjIsmi.Equals("Bitis"))
        {
            canSayaci -= 1;
            canText.text = canSayaci.ToString();
            if (canSayaci <= 0)
            {
                OyunuKaybet();
            }
        }
    }

    void OyunuKazandiniz()
    {
        print("Oyunu Kazandiniz");
    }

    void OyunuKaybet()
    {
        print("Oyunu Kaybettiniz");
        oyunDevam = false;
    }
}