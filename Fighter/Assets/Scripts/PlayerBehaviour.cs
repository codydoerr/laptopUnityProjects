using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //Whether it is public or private - default is private
    //What object type it is
    //What name
    //Starting value
    [SerializeField] private float speed = 5f;
    [SerializeField] private bool isPlayerAlive = true;
    public int lives = 3;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    public static float horizontalUpperLimit = 9.5f;
    public static float horizontalLowerLimit = -9.5f;
    public static float verticalUpperLimit = 0f;
    public static float verticalLowerLimit = -4.45f;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int weaponType = 1;
    //int float bool
    void Start()
    {

    }


    void Update()
    {
        Movement();
        Shooting();
        ChangeWeapons();
    }
    void Movement()
    {
        // transform.position = new Vector3(Random.Range(1, 9), Random.Range(1, 9), Random.Range(1, 9));
        // transform.Translate(new Vector3(1,1,1) * Time.deltaTime * speed);
        //Gets the keyboard inout and moves at the set speed at Time.deltaTime
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime);
        //horizontal limits 9.4 and -9.4
        //vertical limits 5.5 and -5.5


        if (transform.position.x > horizontalUpperLimit || transform.position.x < horizontalLowerLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
        if (transform.position.y > verticalUpperLimit)
        {
            transform.position = new Vector3(transform.position.x, verticalUpperLimit, 0);
        }
        else if(transform.position.y < verticalLowerLimit)
        {
            transform.position = new Vector3(transform.position.x, verticalLowerLimit, 0);
        }
    }
    void Shooting()
    {
        //I want 3 weapon types
        //1 bullet, 2 bullets, 3 bullets

        //when space key is pressed, shoot a bullet
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (weaponType == 1)
            {
                Instantiate(projectilePrefab, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
            } else if(weaponType == 2)
            {
                Instantiate(projectilePrefab, transform.position + new Vector3(0.5f, 1f, 0), Quaternion.identity);
                Instantiate(projectilePrefab, transform.position + new Vector3(-0.5f, 1f, 0), Quaternion.identity);
            } else if (weaponType == 3)
            {
                Instantiate(projectilePrefab, transform.position + new Vector3(.75f, 1f, 0), Quaternion.Euler(0, 0, -30));
                Instantiate(projectilePrefab, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
                Instantiate(projectilePrefab, transform.position + new Vector3(-.75f, 1f, 0), Quaternion.Euler(0, 0, 30));
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            lives--;
        }
    }
    void ChangeWeapons()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponType = 1;
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponType = 2;
        } else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponType = 3;
        }
    }
    public void Damaged()
    {
        lives--;
        if (lives < 0)
            Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Powerup(Clone)")
        {
            speed = 8f;
        }
    }

}