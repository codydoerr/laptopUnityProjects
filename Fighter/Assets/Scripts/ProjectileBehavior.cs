using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{

    [SerializeField] private float projectileSpeed = 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1 * projectileSpeed * Time.deltaTime, 0));
        //transform.Rotate(0f, 0f, 90f, Space.World);
        if (transform.position.y > 7f)
        {
            Destroy(gameObject);
        }
    }
}
