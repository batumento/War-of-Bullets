using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(turnSpeed, turnSpeed, turnSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {

        SceneManager.LoadScene(1);

    }
}
