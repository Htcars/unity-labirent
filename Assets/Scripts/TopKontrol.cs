
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class topcontrol : MonoBehaviour
{
    public Button btn;
    
    public float Hiz = 1;
    public float donusHizi = 1f;
    public float zamanSayaci = 500;
    public float canSayaci = 50;
    public Text zamanText, canText, durum;
    bool oyunDevam = true;
    bool oyunTamam = false;
    public static int skor;
    public Text skorText;
    //public static Button restart;

    // Start is called before the first frame update
    void Start()
    {
        skor = 0;
    }
    
    void Update()
    {
        skorText.text = skor.ToString();
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
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(new Vector3(0,0,1 * Hiz * Time.deltaTime));
                
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, 90*donusHizi*Time.deltaTime, 0);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, -90 * donusHizi * Time.deltaTime, 0);
            }


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