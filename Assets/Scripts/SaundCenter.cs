using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaundCenter : MonoBehaviour
{
    public AudioClip[] sounds;

    private AudioSource audioSrc => GetComponent<AudioSource>();

    public void  PlaySound(AudioClip clip, float volume =1f, bool destroyed = false, float p1 = 1f,float p2 = 1f)
    {
        audioSrc.pitch = Random.Range(p1, p2);

        if (destroyed)
        {
            AudioSource.PlayClipAtPoint(clip, transform.position, volume);
        }
        else
        {
            audioSrc.PlayOneShot(clip, volume);
        }
    }
}
