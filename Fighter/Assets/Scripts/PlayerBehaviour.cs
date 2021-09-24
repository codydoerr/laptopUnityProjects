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
    [SerializeField] private float regularSpeed = 5f;
    [SerializeField] private float boostSpeed = 8f;

    [SerializeField] private bool isPlayerAlive = true;

    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;

    [SerializeField] private int weaponType;
    [SerializeField] private float powerupTime = 5f;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject shieldPrefab;
    [SerializeField] private GameObject boosterPrefab;


    public static float horizontalUpperLimit = 9.5f;
    public static float horizontalLowerLimit = -9.5f;
    public static float verticalUpperLimit = 0f;
    public static float verticalLowerLimit = -4.45f;
<<<<<<< HEAD


    public int lives = 3;
    public bool hasShield = false;

    private GameObject gM;


    private int whichPowerup;
=======
    [SerializeField] private GameObject projectilePrefab;
    public GameObject boosterPrefab;
    [SerializeField] private int weaponType = 1;
>>>>>>> 7b6737f6d0b8a0fcd1c9cf081475a94bc379454d
    //int float bool
    void Start()
    {
        gM = GameObject.Find("GameManager");
        ChangeWeapons(1);
        hasShield = false;
    }


    void Update()
    {
        Movement();
        Shooting();
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
    void ChangeWeapons(int weaponType)
    {
        this.weaponType = weaponType;
    }
    public void Damaged()
    {
        if (!hasShield)
            lives--;
        else if (hasShield)
        {
            hasShield = false;
            shieldPrefab.SetActive(false);
        }
        if (lives < 0)
        {
            Destroy(this.gameObject);
            isPlayerAlive = false;
        }
<<<<<<< HEAD
=======


>>>>>>> 7b6737f6d0b8a0fcd1c9cf081475a94bc379454d
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Powerup(Clone)")
        {
<<<<<<< HEAD
            gM.GetComponent<GameManager>().PlaySound("powerUp");
            whichPowerup = Random.Range(1, 5);
            switch(whichPowerup)
            {
                case 1:
                    Destroy(collision.gameObject);
                    speed = boostSpeed;
                    boosterPrefab.SetActive(true);
                    StartCoroutine(SpeedDown(powerupTime));
                    boosterPrefab.SetActive(false);

                    break;
                case 2:
                    //activate shield
                    Destroy(collision.gameObject);
                    shieldPrefab.SetActive(true);
                    hasShield = true;

                    break;
                case 3:
                    Destroy(collision.gameObject);
                    ChangeWeapons(3);
                    StartCoroutine(PowerupTime(powerupTime));

                    //activate triple bullet
                    break;
                case 4:
                    Destroy(collision.gameObject);
                    ChangeWeapons(2);
                    StartCoroutine(PowerupTime(powerupTime));

                    // activate double bullet
                    break;
            }
=======
            Destroy(collision.gameObject);
            speed = 8f;
            boosterPrefab.SetActive(true);
>>>>>>> 7b6737f6d0b8a0fcd1c9cf081475a94bc379454d
        }
    }
    IEnumerator PowerupTime(float wait)
    {
        yield return new WaitForSeconds(wait);
        ChangeWeapons(1);
        gM.GetComponent<GameManager>().PlaySound("powerDown");
    }
    IEnumerator SpeedDown(float wait)
    {
        yield return new WaitForSeconds(wait);
        speed = regularSpeed;
        gM.GetComponent<GameManager>().PlaySound("powerDown");
    }



}