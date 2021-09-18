using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject topPaddle;
    [SerializeField] private GameObject bottomPaddle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime));
        }

        if(transform.position.y >= 7.5)
        {
            transform.position = new Vector3(transform.position.x, 7.5f,0);
        }
        else if (transform.position.y <= -7.5)
        {
            transform.position = new Vector3(transform.position.x, -7.5f, 0);
        }
    }
}
