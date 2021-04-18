using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleController : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private DoorStates _doorState;
    [SerializeField] private GameObject _locked;
    [SerializeField] private GameObject _pressEtoLockUnlock;
    private bool _isPlayerNearby;
    private bool _isDoorLocked = true;
    public enum Colors
    {
        Red,
        Green,
        Blue
    }
    public Colors Color;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerNearby = true;
            _pressEtoLockUnlock.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerNearby = false;
            _pressEtoLockUnlock.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _isPlayerNearby)
        {
            BlueKeyCheck();
            RedKeyCheck();
            GreenKeyCheck();
        }
    }

    private void BlueKeyCheck()
    {
        if (Color == Colors.Blue && KeyHolder.singleton.HasBlueKey)
        {
            ChangeDoorState();
        }
        else /// play error sound if player hasnt got a key
            if (Color == Colors.Blue && !KeyHolder.singleton.HasBlueKey)
            {
                _audioSource.clip = AudioManager.singleton.ErrorSound;
                _audioSource.Play();
            }
    }

    private void RedKeyCheck()
    {
        if (Color == Colors.Red && KeyHolder.singleton.HasRedKey)
        {
            ChangeDoorState();
        }
        else /// play error sound if player hasnt got a key
            if (Color == Colors.Red && !KeyHolder.singleton.HasRedKey)
            {
                _audioSource.clip = AudioManager.singleton.ErrorSound;
                _audioSource.Play();
            }
    }

    private void GreenKeyCheck()
    {
        if (Color == Colors.Green && KeyHolder.singleton.HasGreenKey)
        {
            ChangeDoorState();
        }
        else /// play error sound if player hasnt got a key
            if (Color == Colors.Green && !KeyHolder.singleton.HasGreenKey)
            {
                _audioSource.clip = AudioManager.singleton.ErrorSound;
                _audioSource.Play();
            }
    }

    private void ChangeDoorState()
    {

        if (!_doorState.IsDoorOpen)
        {
            _isDoorLocked = !_isDoorLocked;
            if (_isDoorLocked)
            {
                _doorState.State = DoorStates.States.Locked;
            }
            else
            {
                _doorState.State = DoorStates.States.Unlocked;
            }
            _locked.SetActive(_isDoorLocked);

            /// play acces sound
            _audioSource.clip = AudioManager.singleton.AccesSound;
            _audioSource.Play();
        }
        else
        {
            /// play acces sound
            _audioSource.clip = AudioManager.singleton.ErrorSound;
            _audioSource.Play();
        }






        

    }
}
