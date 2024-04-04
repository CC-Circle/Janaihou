using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    [SerializeField] AudioSource source1;
    [SerializeField] AudioSource source2;
    [SerializeField] AudioClip clip1;
    [SerializeField] AudioClip clip2;
    void Start()
    {
        source1.PlayOneShot(clip1);
    }

    // Update is called once per frame
    void Update()
    {
        if (TIME_MANAGER.is_revtime == true)
        {
            if (source2.isPlaying == false)
            {
                source1.mute = true;
                source2.PlayOneShot(clip2);
            }
        }
        else
        {
            if (source2.isPlaying == true)
            {
                source2.Stop();
                source1.mute = false;
            }
        }
    }
}
