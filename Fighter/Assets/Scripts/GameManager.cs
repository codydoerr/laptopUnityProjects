using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float waitTime = 1f;
    public GameObject enemyPrefab;
    public GameObject cloudPrefab;
    public GameObject playerPrefab;
    public GameObject powerUpPrefab;
    // Start is called before the first frame update
    void Start()
    {
        CreateSky();
        SpawnPlayer();
        InvokeRepeating("SpawnEnemy", waitTime, waitTime);
        InvokeRepeating("SpawnPowerup", 3f, 4f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, new Vector3(Random.Range(PlayerBehaviour.horizontalLowerLimit, PlayerBehaviour.horizontalUpperLimit) ,6f ,0), Quaternion.Euler(new Vector3(0,0,180)));
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
