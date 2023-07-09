using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class player : MonoBehaviour
{
    ////////////////////////////////
    //aesthetics
    public Animator animator;
    public Camera mainCam;
    public float fov, zoom, zoommod;
    float camShakeAmt = 0.1f;
    public float camShakeTim = 0.1f;

    public GameObject movingparticle;

    ////////////////////////////////
    //Scores
    public ScoreManager ScoreManager;

    ////////////////////////////////
    //Death
    public CameraShake camShake;
    public GameObject deathblood;
    public GameObject DeathBang;
    public UnityEvent Deathmessage;

    ////////////////////////////////
    //slowdown values
    public float slowdownFactor = 0.05f;
    public bool slowMo;
    public TimeChange timeChange;
    public bool paused;

    ////////////////////////////////
    //character move speed
    [SerializeField]
    float moveSpeed = 5f;


    ////////////////////////////////
    //players body
    public GameObject pl;
    Rigidbody2D rb;


    ////////////////////////////////
    //audio
    public AudioSource dashAudioSrc;
    public AudioSource DeathslashAudioSrc;


    ////////////////////////////////
    //detect touch, movement
    Touch touch;
    Rect touchscreen;
    Vector3 touchPosition, whereToMove;
    bool isMoving = false;
    float previousDistanceToTouchPos, currentDistanceToTouchPos;
    bool walltouch;
    public GameObject ghost;


    ////////////////////////////////
    //respawn
    public Transform playerRespawn;




    //Runs at the start
    void Start()
    {
        transform.position = playerRespawn.position;
        rb = GetComponent<Rigidbody2D>();
        slowMo = true;
        fov = mainCam.orthographicSize;
        touchscreen = new Rect(0, Screen.height - 200, Screen.width / 5, Screen.height);
        Debug.Log(Screen.height);
    }


    //Runs every frame
    void Update()
    {
        paused = timeChange.getpaused();
        DoSlowmotion();
        animator.SetBool("Move", isMoving);


        //zooms in and out
        if (mainCam.orthographicSize < fov)
        {
            mainCam.orthographicSize += 1 / zoommod;
        }

        //checks if the player is moving
        if (isMoving && !paused)
        {
            currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;
        }

        if (Input.touchCount > 0 && !isMoving) //if the player is not moving then check for next imput
        {
            touch = Input.GetTouch(0);

            if (!paused && !touchscreen.Contains(touch.position))
            {
                if (touch.phase == TouchPhase.Began)
                {
                    previousDistanceToTouchPos = 0;
                    currentDistanceToTouchPos = 0;
                    isMoving = true;
                    //Instantiate(movingparticle, transform.position, Quaternion.identity);
                    dashAudioSrc.Play(); //play the audio source for dash
                    slowMo = false;
                    touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    touchPosition.z = 0;
                    whereToMove = (touchPosition - transform.position).normalized;
                    rb.velocity = new Vector2(whereToMove.x * moveSpeed * 20, whereToMove.y * moveSpeed * 20);

                }
            }

        }


        if (currentDistanceToTouchPos > previousDistanceToTouchPos)
        {
            isMoving = false;
            slowMo = true;
            rb.velocity = Vector2.zero;
        }

        if (isMoving && !paused)
        {
            previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;
            //Instantiate(ghost, transform.position, Quaternion.identity);
            Instantiate(movingparticle, transform.position, Quaternion.identity);
        }





        //flip the sprite to face the direction it moved
        if (transform.position.x > touchPosition.x && transform.localScale.x < 0
                || transform.position.x < touchPosition.x && transform.localScale.x > 0)
        {
            Flip();
        }




    }

    //Contols when the slowmotion plays (Might change into another script)
    void DoSlowmotion()
    {
        /*if (slowMo)
        {
            Time.timeScale = slowdownFactor;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;

        }
        else
        {
            Time.timeScale = 3;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;

        }*/
        timeChange.MoveSlowmotion(slowMo);

    }


    //Flips the sprite
    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    void Death()
    {
        camShake.Shake(camShakeAmt, camShakeTim);
        Instantiate(deathblood, transform.position, Quaternion.identity);
        Instantiate(DeathBang, transform.position, Quaternion.identity);
        pl.SetActive(false);
        slowMo = true;
        Deathmessage.Invoke();
        timeChange.MoveSlowmotion(slowMo);

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("wall"))
        {
            rb.velocity = new Vector2(-whereToMove.x * moveSpeed * 20, -whereToMove.y * moveSpeed * 20);
        }

        if (col.gameObject.tag.Equals("enemy"))
        {
            DeathslashAudioSrc.Play();
            mainCam.orthographicSize = zoom;
            ScoreManager.addPoint();
        }

        if (col.gameObject.tag.Equals("Damage"))
        {
            isMoving = false;
            slowMo = true;
            rb.velocity = Vector2.zero;
            //transform.position = playerRespawn.position;
            Death();
        }

        //checks if the player is touching the bullet
        if (col.gameObject.tag.Equals("Bullet"))
        {
            isMoving = false;
            slowMo = true;
            rb.velocity = Vector2.zero;
            //transform.position = playerRespawn.position;
            Death();
        }


    }
}
