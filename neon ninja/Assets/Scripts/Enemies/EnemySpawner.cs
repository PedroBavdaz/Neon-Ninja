using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;

    public int wave;
    public float spawncooldown;
    public float multiplier;
    public ScoreManager ScoreManager;
    public bool canspawn = true;

    // Start is called before the first frame update
    void Start()
    {
        wave = 0;
        spawncooldown = 1;
        multiplier = 1;

        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawncooldown);
        while (canspawn)
        {
            yield return wait;

            Instantiate(enemy, new Vector3(Random.Range(transform.position.x - transform.localScale.x / 2,
            transform.position.x + transform.localScale.x / 2), Random.Range(transform.position.y - transform.localScale.y / 2,
            transform.position.y + transform.localScale.y / 2), 0), Quaternion.identity);
        }
    }
}
