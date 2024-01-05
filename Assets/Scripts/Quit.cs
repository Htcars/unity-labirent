using UnityEngine;

public class OyunCikis : MonoBehaviour
{
    // Oyun çýkýþ butonuna týklanýnca çaðrýlacak fonksiyon
    public void CikisYap()
    {
        Debug.Log("Oyundan çýkýlýyor...");
        Application.Quit(); // Oyundan çýkýþ yapar
    }
}
