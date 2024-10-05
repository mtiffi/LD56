using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rig;
    public float speed, flapSpeed, maxSpeed;
    public GameObject jumpLight;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            rig.velocity = new Vector2(rig.velocity.x, 1 * flapSpeed);
            Instantiate(jumpLight,transform.position, Quaternion.identity);
        }

        if (Input.GetKey(KeyCode.A) && rig.velocity.x > -maxSpeed)
        {
            rig.AddForce(new Vector2(-1 * Time.deltaTime * speed, 0));
        }
        if (Input.GetKey(KeyCode.D) && rig.velocity.x < maxSpeed)
        {
            rig.AddForce(new Vector2(1 * Time.deltaTime * speed, 0));
        }


    }
}
