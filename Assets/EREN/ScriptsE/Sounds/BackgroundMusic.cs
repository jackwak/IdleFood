using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource audioSource;
    [Space]
    [EditorAttributes.ReadOnly, SerializeField]private AudioClip currentAudioClip;
    [EditorAttributes.ReadOnly, SerializeField] private int currentChoosenMusicIndex;
    [EditorAttributes.ReadOnly, SerializeField] private float currentChoosenMusicLegnth;


    [EditorAttributes.Button("ChangeMusic", 45f)]
    public void ChangeMusic() => StartMusic();
    [Space]
    private int lastChoosenMusicIndex;
   
    [SerializeField] private List<AudioClip> clipList;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lastChoosenMusicIndex = -1;

        StartMusic();
    }

    private void StartMusic()
    {
        StopCoroutine(CheckMusicEndTime());
        ChooseMusic();
        StartCoroutine(CheckMusicEndTime());

        audioSource.Play();
    }
    private void ChooseMusic()
    {
        while (currentChoosenMusicIndex == lastChoosenMusicIndex)
        {
            currentChoosenMusicIndex = Random.Range(0, clipList.Count);
        }
        if(lastChoosenMusicIndex == -1)
            currentChoosenMusicIndex = Random.Range(0, clipList.Count);

        lastChoosenMusicIndex = currentChoosenMusicIndex;

        currentAudioClip = clipList[currentChoosenMusicIndex];
        audioSource.clip = currentAudioClip;
        currentChoosenMusicLegnth = currentAudioClip.length;
    }
    IEnumerator CheckMusicEndTime()
    {
        yield return new WaitForSeconds(currentChoosenMusicLegnth);
        StartMusic();
    }

}
