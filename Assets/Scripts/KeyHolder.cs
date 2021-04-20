using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    public static KeyHolder singleton;
    private AudioSource _audioSource;
    [HideInInspector] public bool HasRedKey;
    [HideInInspector] public bool HasBlueKey;
    [HideInInspector] public bool HasGreenKey;
    [SerializeField] private GameObject RedKeyUI;
    [SerializeField] private GameObject BlueKeyUI;
    [SerializeField] private GameObject GreenKeyUI;

    private void Start()
    {
        if(singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
        _audioSource = GetComponent<AudioSource>();
    }

    public void ActivateRedUICard()
    {
        _audioSource.Play();
        RedKeyUI.SetActive(true);
    }
    public void ActivateBlueUICard()
    {
        _audioSource.Play();
        BlueKeyUI.SetActive(true);
    }
    public void ActivateGreenUICard()
    {
        _audioSource.Play();
        GreenKeyUI.SetActive(true);
    }
}
