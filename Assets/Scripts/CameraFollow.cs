using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private GameObject player;
    private Vector3 offset; 
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position; // Kamera ve oyuncu arasýndaki farký offset deðiþkenine oyun ilk baþlarken atýyoruz
    }


    /*LateUpdate'in Update'den farký adý üzerinde, Update metodundan sonra çalýþýr Kamera takibini genellikle LateUpdate metodunda yazarýz
    Çünkü Update metodunun içine yazarsak her ikisi de hareket ediyorsa, önce kameranýn hareket etme olasýlýðý vardýr, o zaman nesne hareket edecek ve artýk ortalanmayacaktýr.*/
    private void LateUpdate()
    {
        if (player.transform.position == null)
        {
            //Geri Döndüðünde Bak ve Çöz !!
        }
        transform.position = player.transform.position + offset;
    }
}
