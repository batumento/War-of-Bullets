using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float bulletSpeed= 5f;
    public GameObject owner;


   

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Target>() == false)
        {
            
            Destroy(gameObject);
        }
    }
}
