using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private AudioClip clipToPlay;
    [Header("Health Settings")]
    public bool healthPower = false;
    public int healthAmount = 5;
    [Header("Ammo Settings")]
    public bool ammoPower = false;
    public int ammoAmount = 5;
    [Header("Transform Settings")]
    public float turnSpeed = -1f;
    [Header("Scale Setting")]
    [SerializeField] private float period = 2f;
    [SerializeField] Vector3 scaleVector;
    [SerializeField] private float scaleFactor;
    private Vector3 startScale;
    private void Awake()
    {
        startScale = transform.localScale;
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(turnSpeed,0f,0f);
        SinusWawe();
    }

    private void SinusWawe()
    {
        if (period <= 0f)
        {
            period = 0.1f;
        }
        float cycles = Time.timeSinceLevelLoad / period;
        const float piX2 = Mathf.PI * 2;

        float sinusWawe = Mathf.Sin( cycles * piX2);
        scaleFactor = sinusWawe / 2 + 0.5f;
        Vector3 offset = scaleFactor * scaleVector;
        transform.localScale = startScale + offset;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(clipToPlay, transform.position);
            if (healthPower)
            {
                other.gameObject.GetComponent<Target>().GetHealth += healthAmount;
            }
            else if (ammoPower)
            {
                other.gameObject.GetComponent<Attack>().GetAmmo += ammoAmount;
            }
            Destroy(gameObject);
        }
        else
        {
            return;
        }
        
    }
}
