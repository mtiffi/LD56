using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lightning : MonoBehaviour
{

    private Light2D light2d;
    public float lightningIntensity;
    public float defaultIntensity;
    public float intensityDecrease, randomMin, randomMax;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        light2d = GetComponent<Light2D>();
        audioSource = GetComponent<AudioSource>();
        Invoke("Light", Random.Range(randomMin, randomMax));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Light();
        }
    }

    private void Light()
    {
        audioSource.Play();
        light2d.intensity = lightningIntensity;
        Invoke("Light", Random.Range(randomMin, randomMax));
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (light2d.intensity > defaultIntensity)
        {
            light2d.intensity -= intensityDecrease;
        }
        else
        {
            light2d.intensity = defaultIntensity;
        }
    }
}
