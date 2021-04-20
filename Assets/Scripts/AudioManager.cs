using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager singleton;

    public AudioClip ErrorSound;
    public AudioClip AccesSound;
    public AudioClip OpenDoorSound;
    public AudioClip CollectSound;
    public AudioClip FinalSound;

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
    }


}
