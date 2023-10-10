using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;

    public enum audioType {Music, Sound}
    public audioType type;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float pitch;
    [Range(0f, 1f)]
    public float defaultVolume;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}