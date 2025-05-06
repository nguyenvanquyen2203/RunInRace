using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }
    public AudioData audioData;
    public MusicSound musicSounds;
    public SFXSound[] SFXSounds;
    public enum Audio_Type
    {
        Music,
        SFX
    }
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        AudioSource temp = gameObject.AddComponent<AudioSource>();
        musicSounds.InitSrc(temp);
        musicSounds.SetVolumn(audioData.musicVolumn);
        foreach (SFXSound s in SFXSounds)
        {
            AudioSource src = gameObject.AddComponent<AudioSource>();
            s.InitSrc(src);
            s.SetVolumn(audioData.SFXVolumn);
        }
    }
    public void PlaySFX(string name)
    {
        SFXSound sound = Array.Find(SFXSounds, s => s.name == name);
        sound.PlayMusic();
    }
    public void PlayMusic(string name)
    {
        musicSounds.PlayMusic(name);
    }
    public void SetVolumn(float _volumn, Audio_Type type)
    {
        if (type == Audio_Type.Music) SetMusicVol(_volumn);
        else SetSFXVol(_volumn);
    }
    private void SetMusicVol(float _volumn)
    {
        audioData.musicVolumn = _volumn;
        musicSounds.SetVolumn(_volumn);
    }
    private void SetSFXVol(float _volumn)
    {
        audioData.SFXVolumn = _volumn;
        foreach (SFXSound s in SFXSounds) s.SetVolumn(_volumn);
    }
    public float GetVolumn(Audio_Type type)
    {
        if (type == Audio_Type.Music) return audioData.musicVolumn;
        return audioData.SFXVolumn;
    }
}
