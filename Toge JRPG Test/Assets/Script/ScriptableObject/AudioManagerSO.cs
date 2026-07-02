using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SoundClip
{
    public SoundType soundType;
    public AudioClip clip;
}

[Serializable]
public class MusicClip
{
    public MusicType musicType;
    public AudioClip clip;
}

[CreateAssetMenu(fileName = "AudioManagerSO", menuName = "Scriptable Objects/AudioManagerSO")]

public class AudioManagerSO : ScriptableObject
{
    public List<MusicClip> musics = new List<MusicClip>();
    public List<SoundClip> sounds = new List<SoundClip>();
}
