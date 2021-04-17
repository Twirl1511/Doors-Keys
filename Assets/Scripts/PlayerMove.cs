using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController _characterController;
    [SerializeField] private float _speed = 10f;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        Vector3 move = transform.right * x + transform.forward * z;
        _characterController.Move(move);
    }
}
