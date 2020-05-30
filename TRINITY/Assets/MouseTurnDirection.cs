﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTurnDirection : MonoBehaviour
{

    public GameObject arrow;
    public GameObject spawnPoint;
    public float speed = .5f;
    bool canshoot;
    private float dashTime;
    public float startDashTime;
    public float cooldownTime = 2;
    private float nextDashTIme = 0;
    bool shot = false;



    // Start is called before the first frame update
    void Start()
    {
        dashTime = startDashTime;

    }

    // Update is called once per frame
    void Update()
    {

        turning();
        if (Time.time > nextDashTIme)
        {

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                shoot();

            }
        }

    }
    void turning()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direc = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.right = direc;

    }

    void shoot()
    {

        arrow.transform.gameObject.SetActive(true);
        GameObject projectile = (GameObject)Instantiate(arrow, spawnPoint.transform.position, (Quaternion.identity));
        projectile.transform.right = transform.right;
        nextDashTIme = Time.time + cooldownTime;


    }

}







