using System;
using Unity.VisualScripting;
using UnityEngine;
[System.Serializable]
public class MusicSound
{
    public Sound[] musics;
    private AudioSource src;
    private Sound playingMusic;
    private float volumn;
    public void InitSrc(AudioSource _src)
    {
        src = _src;
        src.loop = true;
    }
    public void PlayMusic(string name)
    {
        playingMusic = Array.Find(musics, s => s.name == name);
        src.clip = playingMusic.clip;
        src.volume = playingMusic.volumn * volumn;
        src.Play();
    }
    public void SetVolumn(float _volumn)
    {
        volumn = _volumn;
        if (playingMusic != null) src.volume = playingMusic.volumn * volumn;
    } 
}
