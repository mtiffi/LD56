using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rig;
    private bool dead, started;
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
        if (!started && Input.GetKeyDown(KeyCode.Space))
        {
            started = true;
            GameObject.Find("StartText").GetComponent<TextMeshProUGUI>().text = "";

        }
        if (dead || !started)
        {
            rig.velocity = Vector2.zero;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            rig.velocity = new Vector2(rig.velocity.x, 1 * flapSpeed);
            Instantiate(jumpLight, transform.position, Quaternion.identity);


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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            GameObject.Find("DiedText").GetComponent<TextMeshProUGUI>().text = "YOU DIED";
            GameObject.Find("RestartText").GetComponent<TextMeshProUGUI>().text = "Hold R to Restart";

            dead = true;
            GetComponentInChildren<Light2D>().intensity = 0;
            GetComponent<SpriteRenderer>().enabled = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("End"))
        {
            GameObject.Find("DiedText").GetComponent<TextMeshProUGUI>().text = "YOU WIN";
            GameObject.Find("RestartText").GetComponent<TextMeshProUGUI>().text = "Hold R to Restart";

            dead = true;
            GetComponentInChildren<Light2D>().intensity = 0;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
