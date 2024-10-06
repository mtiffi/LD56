using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScr : MonoBehaviour
{

    public GameObject lights;
    public float lightFrequency;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > lightFrequency) {
            timer = 0;
            Vector3 spawn = Random.onUnitSphere * 2 + transform.position;
            Instantiate(lights, new Vector3(spawn.x, spawn.y, transform.position.z), Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            Debug.Log("Won");
        }
    }
}
