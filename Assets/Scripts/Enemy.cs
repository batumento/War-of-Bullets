using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] movePoints;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float shootRange = 10f;
    [SerializeField] private float reloadTime = 5f;
    [SerializeField] private bool isReloaded = false;
    [SerializeField] private LayerMask shootLayer;
    private Transform aimTransform;

    private bool canMoveRight = true;
    private Attack attack;
    private void Awake()
    {
        attack = GetComponent<Attack>();
        aimTransform = attack.GetFireTransform;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyFire();

        CheckCanMoveRight();
        MoveTowards();
        Aim();
    }

    private void Reload()
    {
        attack.GetAmmo = attack.GetClipSize;
        isReloaded = false;
    }

    private void EnemyFire()
    {
        if (attack.GetAmmo <= 0 && isReloaded == false)
        {
            Invoke("Reload", reloadTime);
            isReloaded = true;
        }

        if (attack.GetCurrentFireRate <= 0f && attack.GetAmmo > 0 && Aim())
        {
            attack.FireCommand();

        }
    }

    private void MoveTowards()
    {

        float step = moveSpeed * Time.deltaTime;
        if (Aim()&& attack.GetAmmo > 0)
        {
            return;
        }
        if (!canMoveRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(movePoints[0].position.x,
                transform.position.y,movePoints[0].position.z),step);
            LookAtTheTarget(movePoints[0].position);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(movePoints[1].position.x,
                transform.position.y, movePoints[1].position.z), step);
            LookAtTheTarget(movePoints[1].position);
        }
    }
    private void CheckCanMoveRight()
    {
        if (Vector3.Distance(transform.position, new Vector3(movePoints[0].position.x,
                transform.position.y, movePoints[0].position.z)) <= 0.1f)
        {
            canMoveRight = true;

        }
        else if(Vector3.Distance(transform.position, new Vector3(movePoints[1].position.x,
                transform.position.y, movePoints[1].position.z)) <= 0.1f)
        {
            canMoveRight = false;
            
        }
    }

    private bool Aim()
    {
        if (aimTransform == null)
        {
            aimTransform = attack.GetFireTransform;

        }

        bool hit = Physics.Raycast(aimTransform.position,transform.forward,shootRange,shootLayer);
        Debug.DrawRay(aimTransform.position,transform.forward*shootRange,Color.blue);
        return hit;
    }

    private void LookAtTheTarget(Vector3 newTarget)
    {
        Vector3 newLookPosition = new Vector3(newTarget.x,transform.position.y,newTarget.z);

        Quaternion targetRotation = Quaternion.LookRotation(newTarget - transform.position);
        
        transform.rotation = Quaternion.Lerp(transform.localRotation, targetRotation, moveSpeed * Time.deltaTime);
        
    }
}
