using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float _mouseSens = 100f;
    [SerializeField] private Transform _playerBody;
    private float _xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        LookAround();   
    }

    private void LookAround()
    {
        float mouseHorizontal = Input.GetAxis("Mouse X") * _mouseSens * Time.deltaTime;
        float mouseVertical = Input.GetAxis("Mouse Y") * _mouseSens * Time.deltaTime;

        _xRotation -= mouseVertical;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        // up and down
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        // left and right
        _playerBody.Rotate(Vector3.up * mouseHorizontal);
    }
}
