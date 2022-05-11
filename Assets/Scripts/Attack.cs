using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private GameObject ammo;
    [SerializeField] private bool isPlayer = false;

    private int maxAmmoCount = 5;
    private int ammoCount = 5;
    private Transform fireTransform;
    private AudioClip clipToPlay;
    private AudioSource audioSource;
    private float fireRate = 5f;
    
    





    private float currentFireRate = 0f;
    
    public AudioClip GetClipToPlay
    {
        get { return clipToPlay; }
        set { clipToPlay = value; }
    }
    public float GetCurrentFireRate
    {
        get { return currentFireRate; }

        set { currentFireRate = value; }
    }
    public int GetAmmo
    {
        get
        {
            return ammoCount;
        }
        set
        {
            ammoCount = value;
            if (ammoCount > maxAmmoCount)
            {
                ammoCount = maxAmmoCount;
            }
        }
    }
    public float GetFireRate
    {
        get { return fireRate; }
        set { fireRate = value; }
    }
    public Transform GetFireTransform
    {
        get { return fireTransform; }
        set { fireTransform = value; }
    }
    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFireRate > 0f)
        {
            currentFireRate -= Time.deltaTime;
        }
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (isPlayer)
        {
            if (Input.GetMouseButtonDown(0))
            {

                if (currentFireRate <= 0 && ammoCount > 0)
                {

                    FireCommand();
                }
            }

            switch (Input.inputString)
            {
                case "1":
                    weapons[1].gameObject.GetComponent<Weapon>().GetCurrentWeaponAmmoCount=ammoCount;
                    weapons[0].gameObject.SetActive(true);
                    weapons[1].gameObject.SetActive(false);
                    break;
                case "2":
                    weapons[0].gameObject.GetComponent<Weapon>().GetCurrentWeaponAmmoCount = ammoCount;
                    weapons[1].gameObject.SetActive(true);
                    weapons[0].gameObject.SetActive(false);
                    break;
            }
        }
    }

    public int GetClipSize 
    { 
        get 
        {
            return maxAmmoCount;
        }
        set 
        { maxAmmoCount = value; }

    }

    public void FireCommand()
    {
            currentFireRate = fireRate;
        audioSource.PlayOneShot(clipToPlay);
            GameObject bulletClone = Instantiate(ammo, fireTransform.position, fireTransform.rotation);
            bulletClone.GetComponent<Bullet>().owner = gameObject;
            ammoCount--;
    }
}
