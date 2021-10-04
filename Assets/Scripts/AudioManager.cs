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


    public Sound[] waterSounds;

    public Sound[] sinkSounds;

    public Sound[] toiletSounds;

    public Sound[] doorSounds;

    public Sound[] bathroomSounds;

    public Sound[] kitchenSounds;

    public Sound[] footstepSounds;

    public Sound[] toolSounds;

    public Sound[] music;



    private void Start()
    {



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

        foreach (Sound sound in music)
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

    public void StopMusic()
    {
        foreach (Sound sound in music)
        {
            if (sound.source != null)
            {
                StartCoroutine(FadeOut(sound.source, 1f));
            }

        }
    }

    public void PlayIntroMusic()
    {
        //StopMusic();
        // Play index 0 of the music array
        music[0].source.Play();
    }

    public void PlayGameMusic()
    {
        //StopMusic();
        // Play index 1 of the music array
        music[1].source.Play();
    }

    public void PlayPanicMusic()
    {
        //StopMusic();
        StartCoroutine(FadeUp(music[2].source, 1f));
    }

    public void PlayDeathMusic()
    {
        foreach (Sound sound in music)
        {
            sound.source.Stop();
        }
        music[3].source.Play();
    }

    public void PlayWinMusic()
    {
        //StopMusic();
        StartCoroutine(FadeUp(music[4].source, 1f));
    }

    public void PlayLoseMusic()
    {
        //StopMusic();
        StartCoroutine(FadeUp(music[5].source, 1f));
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

    IEnumerator FadeUp(AudioSource audioSource, float FadeTime)
    {
        audioSource.Play();
        audioSource.volume = 0.0f;

        while (audioSource.volume < 100)
        {
            audioSource.volume += Time.deltaTime / FadeTime;

            yield return null;
        }


    }
}
