using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioController : MonoBehaviour
{
    public AudioClip MaleScream_01;
    public int MaleScream_01_timer = 3;

    public AudioClip FemaleScream_01;
    public int FemaleScream_01_timer = 2;

    public AudioClip SillyScream;
    public int SillyScream_timer = 7;

    public bool keepPlaying = true;

    private AudioSource audioSource;

    // Use this for initialization
    void Start ()
    {
        audioSource = FindObjectOfType<AudioSource>();
        StartCoroutine(SoundOut(MaleScream_01, MaleScream_01_timer));
        StartCoroutine(SoundOut(FemaleScream_01, FemaleScream_01_timer));
        StartCoroutine(SoundOut(SillyScream, SillyScream_timer));
    }

    IEnumerator SoundOut(AudioClip clip, int timer)
    {
        
        StartCoroutine(Halt(timer));

        while (keepPlaying)
        {
            int offset = (int)Random.Range(timer * 0.5f, timer * 1.5f);
            Debug.Log("Offset = " + offset);
            audioSource.PlayOneShot(clip);
            yield return new WaitForSeconds(offset);
        }
    }

    IEnumerator Halt(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
