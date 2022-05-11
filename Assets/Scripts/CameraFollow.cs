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
        offset = transform.position - player.transform.position; // Kamera ve oyuncu aras�ndaki fark� offset de�i�kenine oyun ilk ba�larken at�yoruz
    }


    /*LateUpdate'in Update'den fark� ad� �zerinde, Update metodundan sonra �al���r Kamera takibini genellikle LateUpdate metodunda yazar�z
    ��nk� Update metodunun i�ine yazarsak her ikisi de hareket ediyorsa, �nce kameran�n hareket etme olas�l��� vard�r, o zaman nesne hareket edecek ve art�k ortalanmayacakt�r.*/
    private void LateUpdate()
    {
        if (player.transform.position == null)
        {
            //Geri D�nd���nde Bak ve ��z !!
        }
        transform.position = player.transform.position + offset;
    }
}
