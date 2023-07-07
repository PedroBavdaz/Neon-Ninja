using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeverLoader : MonoBehaviour
{
    public Animator transition;
    public TimeChange timeChange;

    public void LoadNextLevel(int index)
    {
        //StartCoroutine(LoadLevel(index));
        SceneManager.LoadScene(index);
    }

    /*IEnumerator LoadLevel(int levelIndex)
    {
        //play animation
        //transition.SetTrigger("Start");

        //wait
        yield return new WaitForSeconds(1f);


        //Load scene
        SceneManager.LoadScene(levelIndex);
    }*/
}
