using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Deathbang : MonoBehaviour
{

    public float Timemodifier;     // The total of seconds the flash wil last
    public float maxIntensity;     // The maximum intensity the flash will reach
    public UnityEngine.Rendering.Universal.Light2D myLight;        // Your light
    public bool up;

    // Start is called before the first frame update
    void Start()
    {
        myLight.intensity = 0.1f;
        up = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (up && myLight.intensity < maxIntensity)
        {
            myLight.intensity += Time.deltaTime * Timemodifier;
        }
        else if (up && myLight.intensity >= maxIntensity)
        {
            up = false;
        }

        if (!(up))
        {
            myLight.intensity -= Time.deltaTime * Timemodifier;
        }
        if(myLight.intensity <= 0)
        {
            Destroy(gameObject);
        }
    }
}
