using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fletxa : MonoBehaviour
{

    public float speed;
    public float lifeTime;

    public GameObject destroyEffect;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
      
        transform.Translate(transform.up * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {

        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
