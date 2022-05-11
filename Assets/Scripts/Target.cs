using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int health = 2;
    [SerializeField] private GameObject hitFx;
    [SerializeField] private GameObject deadFx;
    [SerializeField] private AudioClip clipTopPlay;
    private int currentHealth;

    public int GetHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
            if (currentHealth > health)
            {
               
                currentHealth = health;
            }
        }
    }
    public int GetMaxHealth
    {
        get
        {
            return health;
        }
       
    }
    private void Awake()
    {
        currentHealth = health;
    }
   

    private void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.GetComponent<Bullet>();

        if (bullet)
        {
            if (bullet.owner != gameObject)
            {
                
                currentHealth--;
                AudioSource.PlayClipAtPoint(clipTopPlay, transform.position);
                if (hitFx != null)
                {
                    Instantiate(hitFx, transform.position,Quaternion.identity);
                }
                if (currentHealth <= 0)
                {

                    Die();
                }
                Destroy(other.gameObject);
            }
        }
    }
    private void Die()
    {
        if (deadFx != null)
        {
            Instantiate(deadFx, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
