using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private float speed = 3f;
    public GameObject explosionPrefab;
    public GameObject bomb;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.name == "Enemy_2(Clone)")
        {
            InvokeRepeating("BombDrop", 0.5f, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6f || transform.position.x > 12f)
            Destroy(gameObject);
        if(gameObject.name == "Enemy_1(Clone)")
            transform.Translate(Vector3.down * Time.deltaTime * speed, 0);
        if(gameObject.name == "Enemy_2(Clone)")
            transform.Translate(Vector3.right * Time.deltaTime * speed, 0);
    }
    void BombDrop()
    {
        Instantiate(bomb,transform.position,Quaternion.Euler(0,0,Random.Range(-100,-165)));
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerBehaviour>().Damaged();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
