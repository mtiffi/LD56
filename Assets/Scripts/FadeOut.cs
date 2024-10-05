using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FadeOut : MonoBehaviour
{
    private Light2D light2d;
    public float fadeOutSpeed;
    // Start is called before the first frame update
    void Start()
    {
        light2d = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(light2d.intensity > .01f) {
            light2d.intensity -= fadeOutSpeed;
        } else {
            Destroy(this);
        }
    }
}
