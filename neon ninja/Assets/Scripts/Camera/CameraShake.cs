using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public Camera mainCam;

    float shakeAmmount = 0;

    void Awake()
    {
        if(mainCam == null)
        {
            mainCam = Camera.main;
        }
    }

    public void Shake(float amt, float length)
    {
        shakeAmmount = amt;
        InvokeRepeating("DoShake", 0, 1f);
        Invoke("StopShake", length);
    }

    void DoShake()
    {
        if (shakeAmmount > 0)
        {
            Vector3 camPos = mainCam.transform.position;

            float offsetX = Random.value * shakeAmmount * 2 - shakeAmmount;
            float offsetY = Random.value * shakeAmmount * 2 - shakeAmmount;
            camPos.x += offsetX;
            camPos.y += offsetY;

            mainCam.transform.position = camPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("DoShake");
        mainCam.transform.localPosition = Vector3.zero;
    }
}
