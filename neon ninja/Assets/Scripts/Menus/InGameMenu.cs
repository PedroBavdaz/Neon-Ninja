using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class InGameMenu : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool paused = false;
    public TimeChange timeChange;
    [SerializeField] private Image _img;
    [SerializeField] private Sprite _default, _pressed;
    [SerializeField] private AudioClip _compressClip, _uncompressClip;
    [SerializeField] private AudioSource _source;

    // Start is called before the first frame update
    public void OnPointerDown(PointerEventData eventData)
    {
        _img.sprite = _pressed;
        _source.PlayOneShot(_compressClip);
    }

    // Update is called once per frame
    public void OnPointerUp(PointerEventData eventData)
    {
        _img.sprite = _default;
        _source.PlayOneShot(_uncompressClip);
    }

    public void MenuUp()
    {
        paused = true;
        timeChange.Pause(paused);
    }
    public bool getpaused()
    {
        return paused;

    }

    void Start()
    {
        paused = false;
    }

    void Update()
    {
        if ((Screen.orientation == ScreenOrientation.LandscapeLeft) || (Screen.orientation == ScreenOrientation.LandscapeRight))
        {
            transform.position = new Vector2(150, 1025);
        }
        else if ((Screen.orientation == ScreenOrientation.Portrait) || (Screen.orientation == ScreenOrientation.PortraitUpsideDown))
        {
            transform.position = new Vector2(150, 2375);
        }
    }
}
