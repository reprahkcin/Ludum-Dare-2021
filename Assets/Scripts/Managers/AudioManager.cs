using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    //Singleton
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Audio clips loaded in the inspector
    public Sound[] sounds;

    public Sound[] waterSounds;

    public Sound[] sinkSounds;

    public Sound[] toiletSounds;

    public Sound[] doorSounds;

    public Sound[] bathroomSounds;

    public Sound[] kitchenSounds;

    public Sound[] footstepSounds;

    public Sound[] toolSounds;



    private void Start()
    {

        // Create a sound clip for each sound in the sounds array
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }

        foreach (Sound sound in waterSounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }

        foreach (Sound sound in sinkSounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }

        foreach (Sound sound in toiletSounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }

        foreach (Sound sound in doorSounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }

        foreach (Sound sound in bathroomSounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }

        foreach (Sound sound in kitchenSounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }

        foreach (Sound sound in footstepSounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }

        foreach (Sound sound in toolSounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    // Play a random clip from the sounds array
    public void PlayWaterSound()
    {
        // Pick a random number between 0 and the length of the waterSounds array.
        int randomIndex = UnityEngine.Random.Range(0, waterSounds.Length);
        // Play the clip at the random index of the array.
        waterSounds[randomIndex].source.Play();
    }

    public void PlaySinkSound()
    {
        // Pick a random number between 0 and the length of the sinkSounds array.
        int randomIndex = UnityEngine.Random.Range(0, sinkSounds.Length);
        // Play the clip at the random index of the array.
        sinkSounds[randomIndex].source.Play();
    }

    public void PlayToiletSound()
    {
        // Pick a random number between 0 and the length of the toiletSounds array.
        int randomIndex = UnityEngine.Random.Range(0, toiletSounds.Length);
        // Play the clip at the random index of the array.
        toiletSounds[randomIndex].source.Play();
    }

    public void PlayDoorSound()
    {
        // Pick a random number between 0 and the length of the doorSounds array.
        int randomIndex = UnityEngine.Random.Range(0, doorSounds.Length);
        // Play the clip at the random index of the array.
        doorSounds[randomIndex].source.Play();
    }

    public void PlayBathroomSound()
    {
        // Pick a random number between 0 and the length of the bathroomSounds array.
        int randomIndex = UnityEngine.Random.Range(0, bathroomSounds.Length);
        // Play the clip at the random index of the array.
        bathroomSounds[randomIndex].source.Play();
    }

    public void PlayKitchenSound()
    {
        // Pick a random number between 0 and the length of the kitchenSounds array.
        int randomIndex = UnityEngine.Random.Range(0, kitchenSounds.Length);
        // Play the clip at the random index of the array.
        kitchenSounds[randomIndex].source.Play();
    }

    public void PlayFootstepSound()
    {
        // Pick a random number between 0 and the length of the footstepSounds array.
        int randomIndex = UnityEngine.Random.Range(0, footstepSounds.Length);
        // Play the clip at the random index of the array.
        footstepSounds[randomIndex].source.Play();
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}
