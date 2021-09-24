using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float waitTime = 1f;
<<<<<<< HEAD
    [SerializeField] private float powerUpWaitTime = 5f;
=======
>>>>>>> 7b6737f6d0b8a0fcd1c9cf081475a94bc379454d
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject cloudPrefab;
    public GameObject playerPrefab;
    public GameObject powerUpPrefab;
    public int enemyOneCount = 0;
<<<<<<< HEAD
    public AudioClip powerUpClip;
    public AudioClip powerDownClip;
=======
>>>>>>> 7b6737f6d0b8a0fcd1c9cf081475a94bc379454d
    // Start is called before the first frame update
    void Start()
    {
        CreateSky();
        SpawnPlayer();
        InvokeRepeating("SpawnEnemyOne", waitTime, waitTime);
        InvokeRepeating("SpawnEnemyTwo", 15f, 4f);
<<<<<<< HEAD
        InvokeRepeating("SpawnPowerup", 3f, powerUpWaitTime);
=======
        InvokeRepeating("SpawnPowerup", 3f, 4f);
>>>>>>> 7b6737f6d0b8a0fcd1c9cf081475a94bc379454d
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        ReloadScene();
=======
        if(FindObjectOfType<PlayerBehaviour>()== null)
        {
                waitForReset(5f);
                SceneManager.LoadScene("SampleScene");
        }
>>>>>>> 7b6737f6d0b8a0fcd1c9cf081475a94bc379454d
    }
    public IEnumerator waitForReset(float wait)
    {
        yield return new WaitForSeconds(wait);
<<<<<<< HEAD
    }
    void SpawnEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(PlayerBehaviour.horizontalLowerLimit+2, PlayerBehaviour.horizontalUpperLimit-2 ) ,6f ,0), Quaternion.Euler(new Vector3(0,0,180)));
        enemyOneCount++;

    }
    void SpawnEnemyTwo()
    {
        Instantiate(enemyTwoPrefab, new Vector3(PlayerBehaviour.horizontalLowerLimit, Random.Range(2f, 3.75f), 0), Quaternion.Euler(new Vector3(0, 0, -90)));
        enemyOneCount++;

    }
    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "powerUp":
                GetComponent<AudioSource>().PlayOneShot(powerUpClip);
                return;
            case "powerDown":
                GetComponent<AudioSource>().PlayOneShot(powerDownClip);
                return;
        }
    }
    void ReloadScene()
    {
        if (FindObjectOfType<PlayerBehaviour>() == null)
        {
            waitForReset(5f);
            SceneManager.LoadScene("SampleScene");
        }
=======
    }
    void SpawnEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(PlayerBehaviour.horizontalLowerLimit+2, PlayerBehaviour.horizontalUpperLimit-2 ) ,6f ,0), Quaternion.Euler(new Vector3(0,0,180)));
        enemyOneCount++;

    }
    void SpawnEnemyTwo()
    {
        Instantiate(enemyTwoPrefab, new Vector3(PlayerBehaviour.horizontalLowerLimit, Random.Range(2f, 3.75f), 0), Quaternion.Euler(new Vector3(0, 0, -90)));
        enemyOneCount++;

>>>>>>> 7b6737f6d0b8a0fcd1c9cf081475a94bc379454d
    }
    void SpawnPlayer()
    {
        Instantiate(playerPrefab, new Vector3(0,0,0), Quaternion.identity);
    }
    void CreateSky()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(cloudPrefab, transform.position , Quaternion.identity);
        }
    }
    void SpawnPowerup()
    {
        Instantiate(powerUpPrefab, new Vector3(Random.Range(-10, 10), 7f, 0), Quaternion.identity);
    }
}
