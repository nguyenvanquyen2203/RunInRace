using UnityEngine;
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volumn;
    [Range(.1f, 3f)]
    public float pitch;
}
