using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] private float speed = 0f;
    [SerializeField] private float jumpPower = 0f;
    [SerializeField] private float turnSpeed = 15f;
    [SerializeField] private Transform[] rayStartPoints;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        TakeInput();
    }

    private void TakeInput()
    {
        
        if (Input.GetKey(KeyCode.W) && OnGroundCheck())
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x,Mathf.Clamp((jumpPower * 100) * Time.deltaTime,0f,15f), 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector3(Mathf.Clamp((-speed * 100) * Time.deltaTime,-15f,0f), rigidbody.velocity.y,0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), turnSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector3(Mathf.Clamp((speed * 100) * Time.deltaTime,0f,15f), rigidbody.velocity.y, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 180f, 0f), turnSpeed * Time.deltaTime);//Döndürmek için
        }
        else
        {
            rigidbody.velocity = new Vector3(0f,rigidbody.velocity.y, 0f);
        }
    }

    private bool OnGroundCheck()
    {
        bool hit = false;
        for (int i = 0; i < rayStartPoints.Length; i++)
        {
            hit = Physics.Raycast(rayStartPoints[i].position, -rayStartPoints[i].transform.up, 0.50f);
            Debug.DrawRay(rayStartPoints[i].position, -rayStartPoints[i].transform.up * 0.25f, Color.red);
        }
        if (hit)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
