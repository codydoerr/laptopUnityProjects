using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float horizontalInput;

    public float verticalInput;
    public float horizontalLimit = 4.5f;
    public float verticalLimit = 95f;
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput*speed*Time.deltaTime,0,verticalInput*speed*Time.deltaTime));
        if(transform.position.x >= horizontalLimit)
        {
            transform.position = new Vector3 (horizontalLimit,transform.position.y, transform.position.z);
        }
        if(transform.position.x <= -horizontalLimit)
        {
            transform.position = new Vector3(-horizontalLimit, transform.position.y, transform.position.z);
        }
        if(transform.position.z >= verticalLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, verticalLimit);
        }
        if(transform.position.z <= -4.5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -4.5f);
        }
    }
}
