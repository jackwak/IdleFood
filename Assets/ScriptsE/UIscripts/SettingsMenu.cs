using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    Animator animator;

    bool IsMenuOpen;
    bool IsSoundTurnedOn;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        IsMenuOpen = false;
        IsSoundTurnedOn = true;

    }
    public void ToggleMenu()
    {
        if (!IsMenuOpen)
        {
            //Debug.Log("menü açýldý");
            IsMenuOpen = true;
            this.gameObject.GetComponent<Image>().enabled = true;
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(true);
            //animator.SetBool("OpenAnim", true);   Eðer kullanýrsan <Image>().enabled = true; yu de aktif et
        }
        else if (IsMenuOpen)
        {
            //Debug.Log("menü kapandý");
            IsMenuOpen = false;
            this.gameObject.GetComponent<Image>().enabled = false;
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
            //animator.SetBool("OpenAnim", false);   Eðer kullanýrsan <Image>().enabled = true; yu de aktif et
        }
    }

    public void ToggleSound()
    {
        if (IsSoundTurnedOn)
        {
            //Debug.Log("ses kapandý");
            IsSoundTurnedOn = false;
        }
        else
        {
            //Debug.Log("ses açýldý");
            IsSoundTurnedOn = true;
        }
    }
    public void UnMute()
    {
        Debug.Log("Ses Açýldý");
        IsSoundTurnedOn = true;
    }
    public void Mute()
    {
        Debug.Log("Ses Kapatýldý");
        IsSoundTurnedOn = false;
    }
}
