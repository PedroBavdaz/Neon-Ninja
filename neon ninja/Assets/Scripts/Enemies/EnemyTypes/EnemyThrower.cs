using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class EnemyThrower : MonoBehaviour
{

    //floats
    public float fireRate;
    public float nextFire;
    public float walkSpeed, range;
    private float distToPlayer;


    //Bools
    public bool mustPatrol;
    private bool canShoot;


    //Misc
    public Rigidbody2D rb;
    public Transform player;

    //death animations
    public GameObject deathblood;
    public GameObject DeathBang;

    //shooting
    public GameObject bullet;
    public GameObject muzzleFlash;
    public Vector3 bulletflashoffset = new Vector3(1, 0, 0);
    public float camShakeAmt = 0.1f;
    public float camShakeTim = 0.1f;
    public CameraShake camShake;

    //audio
    public AudioSource bulletAudioSrc;

    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
        canShoot = true;
        nextFire = Time.time;

    }

    // Update is called once per frame
    void Update()
    {

        if (!(Time.timeScale == 2))
        {
            bulletAudioSrc.pitch = 0.5f;
        }
        else
        {
            bulletAudioSrc.pitch = 1f;
        }

        //activates partol mode


        if (mustPatrol)
        {
            Patrol();
        }

        //calculates distance to player
        distToPlayer = Vector2.Distance(transform.position, player.position);


        if (distToPlayer <= range)
        {
            if (player.position.x > transform.position.x && transform.localScale.x < 0
                || player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }

            mustPatrol = false;
            rb.velocity = Vector2.zero;

            if (canShoot)
            {
                Shoot();
            }
        }
        else
        {
            mustPatrol = true;
        }

    }


    //Patrol instructions
    void Patrol()
    {
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    //Flips sprite
    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        bulletflashoffset = new Vector3(-bulletflashoffset.x, 0, 0);
        mustPatrol = true;
    }

    //Shoots a projectile to the player
    void Shoot()
    {

        canShoot = false;

        if (Time.time > nextFire)
        {
            bulletAudioSrc.Play();
            Instantiate(bullet, transform.position + bulletflashoffset, Quaternion.identity);
            Instantiate(muzzleFlash, transform.position + bulletflashoffset, Quaternion.identity);
            nextFire = Time.time + fireRate;

            //handle camera shaking
            //camShake.Shake(camShakeAmt, 0.05f);
        }

        canShoot = true;

    }

    //Collisions
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            camShake.Shake(camShakeAmt, camShakeTim);
            Instantiate(deathblood, transform.position, Quaternion.identity);
            Instantiate(DeathBang, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
