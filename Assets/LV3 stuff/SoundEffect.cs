using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource src;
    public AudioClip info, pause, close;

    public void Info()
    {
        src.clip = info;
        src.Play();
    }
    public void Pause()
    {
        src.clip = pause;
        src.Play();
    }
    public void Close()
    {
        src.clip = close;
        src.Play();
    }
}
