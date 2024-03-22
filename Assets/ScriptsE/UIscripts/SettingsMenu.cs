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
            //Debug.Log("men� a��ld�");
            IsMenuOpen = true;
            this.gameObject.GetComponent<Image>().enabled = true;
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(true);
            //animator.SetBool("OpenAnim", true);   E�er kullan�rsan <Image>().enabled = true; yu de aktif et
        }
        else if (IsMenuOpen)
        {
            //Debug.Log("men� kapand�");
            IsMenuOpen = false;
            this.gameObject.GetComponent<Image>().enabled = false;
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
            //animator.SetBool("OpenAnim", false);   E�er kullan�rsan <Image>().enabled = true; yu de aktif et
        }
    }

    public void ToggleSound()
    {
        if (IsSoundTurnedOn)
        {
            //Debug.Log("ses kapand�");
            IsSoundTurnedOn = false;
        }
        else
        {
            //Debug.Log("ses a��ld�");
            IsSoundTurnedOn = true;
        }
    }
    public void UnMute()
    {
        Debug.Log("Ses A��ld�");
        IsSoundTurnedOn = true;
    }
    public void Mute()
    {
        Debug.Log("Ses Kapat�ld�");
        IsSoundTurnedOn = false;
    }
}
