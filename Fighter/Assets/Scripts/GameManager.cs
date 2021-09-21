using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float waitTime = 1f;
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject cloudPrefab;
    public GameObject playerPrefab;
    public GameObject powerUpPrefab;
    public int enemyOneCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        CreateSky();
        SpawnPlayer();
        InvokeRepeating("SpawnEnemyOne", waitTime, waitTime);
        InvokeRepeating("SpawnEnemyTwo", 15f, 4f);
        InvokeRepeating("SpawnPowerup", 3f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<PlayerBehaviour>()== null)
        {
                waitForReset(5f);
                SceneManager.LoadScene("SampleScene");
        }
    }
    public IEnumerator waitForReset(float wait)
    {
        yield return new WaitForSeconds(wait);
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
