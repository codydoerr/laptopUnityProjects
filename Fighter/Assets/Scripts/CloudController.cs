using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    private float newScale;
    private float newAlpha;
    public float speed = 5f;
    private Color newColor;
    // Start is called before the first frame update
    void Start()
    {
        newColor = this.GetComponent<SpriteRenderer>().color;
        newAlpha = Random.Range(0.2f, 0.8f);
        newColor.a = newAlpha;
        this.GetComponent<SpriteRenderer>().color = newColor;
        newScale = Random.Range(-.1f, .5f);
        transform.position = new Vector3(Random.Range(-11.5f, 11.5f), Random.Range(-6f,6f), 0);
        transform.localScale = new Vector3(newScale,newScale,1);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -1 * speed * Time.deltaTime, 0));
        if(transform.position.y < -8f)
        {
            transform.position = (new Vector3(transform.position.x, 6f, 0));
        }
    }
}
