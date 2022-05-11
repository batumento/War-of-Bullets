using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject levelFinishParent;
    private bool levelFinished;
    private Target playerHealth;

    public bool GetLevelFinish
    {
        get
        {
            return levelFinished;
        }
    }
    private void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Target>();
    }

    // Update is called once per frame
    void Update()
    {
        int enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount <= 0 || playerHealth.GetHealth <= 0)
        {
           levelFinishParent.gameObject.SetActive(true);
            levelFinished = true;
        }
        else
        {
            levelFinishParent.gameObject.SetActive(false);
            levelFinished = false;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(1);
    }
}
