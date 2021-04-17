using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCursor : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
