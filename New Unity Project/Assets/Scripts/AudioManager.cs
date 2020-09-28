using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System;
[System.Serializable]
public class Sound
{
    public string name;
    public AudioMixerGroup audioMixerGroup;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;

    public bool loop;
    public bool playOnAwake;

    [Range(0f, 1f)]
    public float spatialBlend;
    [Range(0f, 500f)]
    public float minRange;
    [Range(0f, 500f)]
    public float maxRange;

    [HideInInspector]
    public AudioSource source;

}

[System.Serializable]
public class Music
{

    public string name;
    public AudioMixerGroup audioMixerGroup;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;

    public bool loop;
    public bool playOnAwake;


    [HideInInspector]
    public AudioSource source;

}


public class AudioManager : MonoBehaviour
{
    private AudioSource[] allAudio;
    public static AudioManager instance;
    public Sound[] sounds;
    public Music[] music;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.audioMixerGroup;
            s.source.spatialBlend = s.spatialBlend;
            s.source.minDistance = s.minRange;
            s.source.maxDistance = s.maxRange;
        }

        foreach (Music m in music)
        {
            m.source = gameObject.AddComponent<AudioSource>();
            m.source.clip = m.clip;
            m.source.volume = m.volume;
            m.source.pitch = m.pitch;
            m.source.loop = m.loop;
            m.source.outputAudioMixerGroup = m.audioMixerGroup;
        }
    }

    public void PlayMusic(string name) //If needed, call FindObjectOfType<AudioManager>().PlayMusic(name);
    {
        Music m = Array.Find(music, music => music.name == name);
        if (m == null)
        {
            Debug.LogWarning("StopSound: " + name + " not found!");
            return;
        }
        m.source.Play();
    }

    public void PlaySFX(string name) //If needed, call FindObjectOfType<AudioManager>().PlaySFX(name);
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("PlaySound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void StopMusic(string name)
    {
        Music m = Array.Find(music, music => music.name == name);
        if (m == null)
        {
            Debug.LogWarning("StopSound: " + name + " not found!");
            return;
        }
        m.source.Stop();

    }

    public void StopSFX(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("StopSound: " + name + " not found!");
            return;
        }
        s.source.Stop();

    }

    public void StopAll()
    {
        allAudio = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audios in allAudio) { audios.Stop(); }
    }


    private void OnLevelWasLoaded(int level)
    {
        level = SceneManager.GetActiveScene().buildIndex;
        if (level == 0) //Menu
        {
            StopAll();
            PlayMusic("Menu");
        }
        else 
        {
            StopAll();
            PlayMusic("Stage1");
        }
       
    }
}
