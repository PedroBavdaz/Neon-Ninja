using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Granade : MonoBehaviour
{
    public float moveSpeed = 7f;

    //player position
    Rigidbody2D rb;
    player target;


    //players original coords
    Vector2 orgplayer;


    //calculating Vector
    Vector2 moveDirection;
    Vector2 lookDirection;
    Vector2 startposition;


    //change parabolic path
    public Vector2 heighty;


    //explosion
    public GameObject GrenadeExplosion;



    // Use this for initialization
    void Start()
    {
        //initial direction vector
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<player>();

        orgplayer = new Vector2(target.transform.position.x, target.transform.position.y);

        startposition = new Vector2(transform.position.x, transform.position.y);
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;

        //initialize with speed already
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y + heighty.y);

        Destroy(gameObject, 2f);



    }

    void Update()
    {
        //rotate buller towards the target
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 5f);
        if ((orgplayer.y > transform.position.y))
        {
            Explode();
        }
    }

    void Explode()
    {
        // Add explosion effect here
        Instantiate(GrenadeExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.name.Equals("Player"))
        {
            //Debug.Log("Hit!");
            //Destroy(gameObject);
        }

        if (col.gameObject.tag.Equals("wall"))
        {
            //Debug.Log("Hit!");
            Destroy(gameObject);
        }


    }

}
