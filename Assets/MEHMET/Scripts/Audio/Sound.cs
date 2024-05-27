using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioClip AudioClip;
    public string Name;
    [Range(0, 1)] public float Volume = 0.3f;
    [Range(0, 1)] public float Pitch = 1f;
    [HideInInspector] public AudioSource AudioSource;
    public bool IsLoop;
}
