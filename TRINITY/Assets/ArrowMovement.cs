using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{

    float speed = 28;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void Collision2D(Collision collision)
    {

        if (collision.gameObject.tag == "SKELETON" || collision.gameObject.tag == "Enemy")
        {

            Debug.Log("XOCA: ");
        }
    }
}
