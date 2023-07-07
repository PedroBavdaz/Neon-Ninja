using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientation : MonoBehaviour
{

    public float fov, zoom, zoommod;
    public Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        //fov = mainCam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Screen.orientation == ScreenOrientation.LandscapeLeft) || (Screen.orientation == ScreenOrientation.LandscapeRight))
        {
            mainCam.orthographicSize = 10f;
        }
        else if ((Screen.orientation == ScreenOrientation.Portrait) || (Screen.orientation == ScreenOrientation.PortraitUpsideDown))
        {
            mainCam.orthographicSize = 23f;
        }
    }
}
