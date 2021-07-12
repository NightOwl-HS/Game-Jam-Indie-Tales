using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] clips;

    public static AudioManager Instance;


    private void Awake()
    {
        Instance = this;
        foreach (Sound sound in clips)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
        }
    }

    public void PlaySound(string soundName)
    {
        for (int i = 0; i < clips.Length; i++)
        {
            if(clips[i].clipName == soundName)
            {
                Sound playSound = clips[i];
                playSound.source.Play();
                Debug.Log("Playing: " + playSound.clipName);
            }
            else
            {
                Debug.Log("Couldnt find sound clip!");
            }
        }
    }
}
