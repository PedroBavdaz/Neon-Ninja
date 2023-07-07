using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;



public class flash : MonoBehaviour
{
    public float Timemodifier;     // The total of seconds the flash wil last
    public float maxIntensity;     // The maximum intensity the flash will reach
    public UnityEngine.Rendering.Universal.Light2D myLight;        // Your light
    int i = 1;
    int r = 1;
    public int delay;

    // Start is called before the first frame update
    void Start()
    {
        myLight.intensity = maxIntensity;
        
    }

    // Update is called once per frame
    void Update()
    {

        myLight.intensity -= Time.deltaTime * Timemodifier;        //Decrease intensity

        if(myLight.intensity <= 0)
        {
            Destroy(gameObject);
        }
        
        
    }


}
