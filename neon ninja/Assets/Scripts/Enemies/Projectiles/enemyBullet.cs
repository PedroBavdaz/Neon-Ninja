using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{

    public float moveSpeed = 7f;

    Rigidbody2D rb;

    player target;
    //public Transform player1;
    Vector2 moveDirection;
    Vector2 lookDirection;

    // Use this for initialization
    void Start()
    {
        //initial direction vector
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<player>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);


    }

    void Update()
    {
        //rotate buller towards the target
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 5f);
    }


    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.name.Equals("Player"))
        {
            //Debug.Log("Hit!");
            Destroy(gameObject);
        }


        if (col.gameObject.tag.Equals("wall"))
        {
            //Debug.Log("Hit!");
            Destroy(gameObject);
        }


    }

}
