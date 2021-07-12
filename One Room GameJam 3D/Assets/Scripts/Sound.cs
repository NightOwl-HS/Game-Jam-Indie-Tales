using UnityEngine;
using UnityEngine.Audio;
[System.Serializable]
public class Sound 
{
    public string clipName;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(0.3f, 3f)]
    public float pitch;

    [HideInInspector]public AudioSource source;
}
