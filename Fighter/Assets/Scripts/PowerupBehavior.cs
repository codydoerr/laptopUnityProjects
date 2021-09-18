using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehavior : MonoBehaviour
{
    private float speed = 7f;
    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime);
        if(transform.position.y > -8f)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}