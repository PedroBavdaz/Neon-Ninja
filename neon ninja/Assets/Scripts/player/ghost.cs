using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ghost : MonoBehaviour
{

    public GameObject movingparticle;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(movingparticle, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.38f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
