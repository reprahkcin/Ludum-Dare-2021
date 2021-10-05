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

    public Sound crowdHappy;

    public Sound crowdUnhappy;

    public Sound[] happyComments;

    public Sound[] unhappyComments;

    public Sound[] genericStatements;

    public Sound[] toiletSounds;

    public Sound[] music;



    private void Start()
    {
        crowdHappy.source = gameObject.AddComponent<AudioSource>();
        crowdHappy.source.clip = crowdHappy.clip;
        crowdHappy.source.volume = crowdHappy.volume;
        crowdHappy.source.pitch = crowdHappy.pitch;
        crowdHappy.source.loop = crowdHappy.loop;

        crowdUnhappy.source = gameObject.AddComponent<AudioSource>();
        crowdUnhappy.source.clip = crowdUnhappy.clip;
        crowdUnhappy.source.volume = crowdUnhappy.volume;
        crowdUnhappy.source.pitch = crowdUnhappy.pitch;
        crowdUnhappy.source.loop = crowdUnhappy.loop;

        foreach (Sound sound in happyComments)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }

        foreach (Sound sound in unhappyComments)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }

        foreach (Sound sound in genericStatements)
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

        foreach (Sound sound in music)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }

        PlayIntroMusic();
        //StartCoroutine(RandomlyPlayComments());

    }


    public void PlayHappySound()
    {
        crowdHappy.source.Play();
    }

    public void PlayUnhappySound()
    {
        crowdUnhappy.source.Play();
    }

    public void PlayHappyComment()
    {
        // Pick a random number between 0 and the length of the happyComments array.
        int randomIndex = UnityEngine.Random.Range(0, happyComments.Length);
        // Play the clip at the random index of the array.
        happyComments[randomIndex].source.Play();
    }

    public void PlayUnhappyComment()
    {
        // Pick a random number between 0 and the length of the unhappyComments array.
        int randomIndex = UnityEngine.Random.Range(0, unhappyComments.Length);
        // Play the clip at the random index of the array.
        unhappyComments[randomIndex].source.Play();
    }

    public void PlayGenericStatement()
    {
        // Pick a random number between 0 and the length of the GenericStatements array.
        int randomIndex = UnityEngine.Random.Range(0, genericStatements.Length);
        // Play the clip at the random index of the array.
        genericStatements[randomIndex].source.Play();
    }

    public void PlayToiletSound()
    {
        // Pick a random number between 0 and the length of the toiletSounds array.
        int randomIndex = UnityEngine.Random.Range(0, toiletSounds.Length);
        // Play the clip at the random index of the array.
        toiletSounds[randomIndex].source.Play();
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
        music[0].source.Stop();
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
    public void StartComments()
    {
        StartCoroutine(RandomlyPlayComments());
    }
    IEnumerator RandomlyPlayComments()
    {
        // Generate a random float between 1-5
        float randomTime = UnityEngine.Random.Range(1f, 5f);
        // Wait for that amount of time
        Debug.Log(StateManager.instance.GetPoints());

        float max = GUIManager.instance.maxBuildings * StateManager.instance.GetAttendees();
        float percent = 100;

        if (max > 0)
        {
            percent = 100 / max * (float)StateManager.instance.GetPoints();
        }
        if (percent > 50)
        {
            //Play happy comment
            PlayHappyComment();
        }
        else
        {
            //Play unhappy comment
            PlayUnhappyComment();
        }
        yield return new WaitForSeconds(randomTime);
        StartCoroutine(RandomlyPlayComments());
    }
}
