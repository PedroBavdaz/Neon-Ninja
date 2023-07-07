using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
    public float Timemodifier;     // The total of seconds the flash wil last
    public float maxIntensity;     // The maximum intensity the flash will reach
    public UnityEngine.Rendering.Universal.Light2D myLight;        // Your light
    public bool up; // Whether the light is increasing or decreasing
    public AudioSource ExplosionAudioSrc; //explosion sound

    //camera shake
    //public float camShakeAmt = 0.1f;
    //public float camShakeTim = 0.1f;
    //public CameraShake camShake;

    // Start is called before the first frame update
    void Start()
    {
        myLight.intensity = 0.1f;
        up = true;
        ExplosionAudioSrc.Play();
        //camShake.Shake(camShakeAmt, camShakeTim);
    }

    // Update is called once per frame
    void Update()
    {
        if (!(Time.timeScale == 2)) //changing the pitch depending on th egame speed
        {
            ExplosionAudioSrc.pitch = 0.1f;
        }
        else
        {
            ExplosionAudioSrc.pitch = 0.5f;
        }

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
        if (myLight.intensity <= 0)
        {
            Destroy(gameObject);
        }
    }
}