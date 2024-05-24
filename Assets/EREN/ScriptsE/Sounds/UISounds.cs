using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISounds : MonoBehaviour
{
    public static UISounds Instance;

    private AudioSource audioSource;
    private AudioClip audioClip;

    [Header("Sounds")]
    [SerializeField] private List<AudioClip> buttonSound;
    [SerializeField] private List<AudioClip> acceptedPurchaseSound;
    [SerializeField] private List<AudioClip> declinedPurchaseSound;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayButtonSound()
    {
        audioSource.clip = buttonSound[Random.Range(0, buttonSound.Count)];
        audioSource.Play();
    }
    public void PlayAcceptedPurchaseSound()
    {
        audioSource.clip = acceptedPurchaseSound[Random.Range(0, acceptedPurchaseSound.Count)];
        audioSource.Play();
    }
    public void PlayDeclinedPurchaseSound()
    {
        audioSource.clip = declinedPurchaseSound[Random.Range(0, declinedPurchaseSound.Count)];
        audioSource.Play();
    }



}
