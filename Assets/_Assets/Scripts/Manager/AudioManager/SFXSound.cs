using UnityEngine;
[System.Serializable]
public class SFXSound : Sound
{
    private AudioSource src;
    public void InitSrc(AudioSource _src)
    {
        src = _src;
        src.clip = clip;
        src.pitch = pitch;
        src.loop = false;
    }
    public void PlayMusic()
    {
        src.Play();
    }
    public void SetVolumn(float _volumn) => src.volume = _volumn * volumn;
}
