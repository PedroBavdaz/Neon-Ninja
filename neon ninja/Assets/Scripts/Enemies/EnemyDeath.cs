using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Task.Delay(1000).ContinueWith(t => bar());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void bar()
    {
        Destroy(gameObject);
    }
}
