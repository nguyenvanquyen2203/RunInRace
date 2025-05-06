using UnityEngine;
[CreateAssetMenu(fileName = "VolumnData", menuName = "VolumnData")]

public class AudioData : ScriptableObject
{
    [Range(0f, 1f)] public float musicVolumn;
    [Range(0f, 1f)] public float SFXVolumn;
}
