using UnityEngine;

public class OyunCikis : MonoBehaviour
{
    // Oyun ��k�� butonuna t�klan�nca �a�r�lacak fonksiyon
    public void CikisYap()
    {
        Debug.Log("Oyundan ��k�l�yor...");
        Application.Quit(); // Oyundan ��k�� yapar
    }
}
