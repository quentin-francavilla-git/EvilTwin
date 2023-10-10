using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public Sound[] sounds;

    // Awake is called before the first frame update
    void Awake()
    {
        if (instance == null) {
            instance = this;
            PlayerPrefs.SetFloat("SoundVolume", .4f);
            PlayerPrefs.SetFloat("MusicVolume", .4f);
        } else {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        initAll();
    }

    private void initAll()
    {
        foreach(Sound sound in sounds) {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            if (sound.type == Sound.audioType.Sound)
                sound.source.volume = PlayerPrefs.GetFloat("SoundVolume") * sound.defaultVolume;
            else if (sound.type == Sound.audioType.Music)
                sound.source.volume = PlayerPrefs.GetFloat("MusicVolume") * sound.defaultVolume;
            sound.source.pitch = sound.pitch;

            sound.source.loop = sound.loop;
            sound.source.Stop();
        }
    }

    private void Start() {
        Play("MainTheme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null) {
            Debug.LogWarning("Sound: \"" + name +"\": not found.");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null) {
            Debug.LogWarning("Sound: \"" + name +"\": not found.");
            return;
        }
        s.source.Stop();
    }

    public void changeVolume(Sound.audioType type, float newVolume)
    {
        foreach (Sound sound in sounds) {
            if (sound.type == type) {
                PlayerPrefs.SetFloat(type+"Volume", newVolume);
                sound.source.volume = newVolume * sound.defaultVolume;
            }
        }
    }

    public void StopAll()
    {
        foreach(Sound sound in sounds) {
            if (sound.type == Sound.audioType.Music)
                sound.source.Stop();
        }
    }
}
