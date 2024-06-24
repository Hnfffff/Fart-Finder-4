using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hovermenu : MonoBehaviour
{
    [SerializeField]
    private AudioSource Audio;
    public AudioClip Hover;
    public AudioClip Click;

    public void PlaySoundHover()
    {
        Audio.PlayOneShot(Hover);
    }

    public void PlaySoundClick()
    {
        Audio.PlayOneShot(Click);
    }
}
