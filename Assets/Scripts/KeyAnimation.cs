using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAnimation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 10;

    private void FixedUpdate()
    {
        transform.Rotate(0, _rotationSpeed, 0, Space.World);
    }
}
