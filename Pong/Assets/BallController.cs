using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody ballRB;
    [SerializeField] private float speed = 7.5f;
    [SerializeField] private float ySpeed = 5f;
    private bool movingLeft = true;
    [SerializeField] private GameObject topPaddle;
    [SerializeField] private GameObject bottomPaddle;
    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-speed*Time.deltaTime, 0,0));
        //ballRB.AddForce(new Vector3(-speed * Time.deltaTime, 0, 0));
    }
    private void OnCollisionEnter(Collision collision)
    {
        speed = -speed;
        if(collision.gameObject.tag == "Top")
        {
            transform.Translate(new Vector3(0, ySpeed, 0));
        }   
        else if(collision.gameObject.tag == "Bottom")
        {
            transform.Translate(new Vector3(0, -ySpeed, 0));
        }
    }
}
