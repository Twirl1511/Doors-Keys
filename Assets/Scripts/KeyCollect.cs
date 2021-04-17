using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollect : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (gameObject.tag)
            {
                case "RedKey":
                    KeyHolder.singleton.HasRedKey = true;
                    KeyHolder.singleton.ActivateRedUICard();
                    break;
                case "BlueKey":
                    KeyHolder.singleton.HasBlueKey = true;
                    KeyHolder.singleton.ActivateBlueUICard();
                    break;
                case "GreenKey":
                    KeyHolder.singleton.HasGreenKey = true;
                    KeyHolder.singleton.ActivateGreenUICard();
                    break;
            }

            Destroy(gameObject);
        }
    }
}
