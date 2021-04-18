using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTrap : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private DoorStates _doorStates;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _light;
    [SerializeField] private GameObject _finalRoom;
    [SerializeField] private GameObject _player;

    private bool _isReadyToFly;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _doorStates.FInalCloseDoor();
            _audioSource.Play();
            _doorStates.State = DoorStates.States.Locked;
            _light.SetActive(true);
            gameObject.GetComponent<Collider>().enabled = false;
            _isReadyToFly = true;
            _player.transform.parent = _finalRoom.transform;
        }
    }

    private void FixedUpdate()
    {
        if (_isReadyToFly)
        {
            _finalRoom.transform.Translate(Vector3.left * Time.deltaTime);
        }
    }

}
