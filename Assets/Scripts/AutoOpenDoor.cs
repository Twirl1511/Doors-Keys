using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoOpenDoor : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetBool(_animator.GetParameter(0).name, true);
            _audioSource.Play();
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetBool(_animator.GetParameter(0).name, false);
            _audioSource.Play();
        }
    }
}
