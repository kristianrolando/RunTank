using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioPlayer instance;
    private bool atFirst;

    private string lastPlayed;
    private void Awake()
    {
        atFirst = true;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name)
    {

        //StopPlay();
        atFirst = false;
        StartCoroutine(PlaySec(name));
        Debug.Log(name);
    }

    public void StopPlay()
    {
        if (atFirst == false)
        {
            Sound s = Array.Find(sounds, sound => sound.name == lastPlayed);
            s.source.Stop();
        }

    }

    IEnumerator PlaySec(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        lastPlayed = name;
        yield return new WaitForSecondsRealtime(100f);
        s.source.Stop();
    }
}


[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)] public float volume;
    [Range(.1f, 3f)] public float pitch;

    [HideInInspector] public AudioSource source;

}