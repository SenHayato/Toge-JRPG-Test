using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioManagerSO audioLibrary;
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioSource musicSoure;

    AudioClip GetSoundClip(SoundType type)
    {
        SoundClip sound = audioLibrary.sounds.Find(s => s.soundType == type);

        return sound != null ? sound.clip : null;
    }

    public void PlaySound(SoundType type, bool isLoop)
    {
        AudioClip clip = GetSoundClip(type);

        if (clip == null)
        {
            Debug.Log($"Sound {type} tidak ditemukan.");
            return;
        }

        if (isLoop)
            PlaySoundLoop(clip);
        else
            PlaySoundOnce(clip);
    }

    void PlaySoundOnce(AudioClip clip)
    {
        soundSource.loop = false;
        soundSource.PlayOneShot(clip);
    }

    void PlaySoundLoop(AudioClip clip)
    {
        soundSource.loop = true;
        soundSource.clip = clip;
        soundSource.Play();
    }

    public void StopSoundLoop()
    {
        soundSource.Stop();
        soundSource.loop = false;
        soundSource.clip = null;
    }

    AudioClip GetMusicClip(MusicType type)
    {
        MusicClip music = audioLibrary.musics.Find(s => s.musicType == type);

        return music != null ? music.clip : null;
    }

    public void PlayMusic(MusicType type)
    {
        AudioClip clip = GetMusicClip(type);
        if (clip == null)
        {
            Debug.Log($"Music {type} tidak ditemukan.");
            return;
        }

        PlayMusicOn(clip);
    }

    void PlayMusicOn(AudioClip clip)
    {
        musicSoure.clip = clip;
        musicSoure.Play();
    }

    public void StopMusic(MusicType type)
    {
        musicSoure.clip = null;
        musicSoure.Stop();
    }
}
