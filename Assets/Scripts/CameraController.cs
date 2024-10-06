using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    private Transform playerTransform;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
        if (Input.GetKey(KeyCode.R))
        {
            timer += Time.deltaTime;
            if (timer > 2)
                SceneManager.LoadScene("Main");

        }
        else
            timer = 0;
    }

}
