using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStates : MonoBehaviour
{
    private AudioSource _audioSource;
    
    private Animator _animator;
    [SerializeField] private GameObject _pressEtoOpen;
    private bool _isPlayerNearby;
    [HideInInspector] public bool IsDoorOpen;
    public enum States
    {
        Locked,
        Unlocked
    }
    public States State;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerNearby = true;
            _pressEtoOpen.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerNearby = false;
            _pressEtoOpen.SetActive(false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _isPlayerNearby && State == States.Unlocked)
        {
            IsDoorOpen = !IsDoorOpen;
            _animator.SetBool(_animator.GetParameter(0).name, IsDoorOpen);

            _audioSource.clip = AudioManager.singleton.OpenDoorSound;
            _audioSource.Play();
        }
        else if(Input.GetKeyDown(KeyCode.E) && _isPlayerNearby && State == States.Locked)
        {
            _audioSource.clip = AudioManager.singleton.ErrorSound;
            _audioSource.Play();
        }
    }

    /// <summary>
    /// wanted to play final door close sound, but had no idea how to manage it properly
    /// </summary>
    public void FInalCloseDoor()
    {
        _animator.SetBool(_animator.GetParameter(0).name, false);
        _audioSource.clip = AudioManager.singleton.OpenDoorSound;
        
        _audioSource.Play();
    }

}
