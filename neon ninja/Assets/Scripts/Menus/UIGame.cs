using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGame : MonoBehaviour
{

    Touch touch;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 )
        {
            Destroy(gameObject);
        }
    }
}
