using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] Sprite _OnSound;
    [SerializeField] Sprite _OffSound;
    //Animator animator;

    bool IsMenuOpen;
    bool IsSoundTurnedOn;

    private void Awake()
    {
        //animator = GetComponent<Animator>();
        IsMenuOpen = false;
        IsSoundTurnedOn = true;
    }
    public void ToggleMenu()
    {
        if (!IsMenuOpen)
        {
            //Debug.Log("men� a��ld�");
            IsMenuOpen = true;
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(true);
            //this.gameObject.transform.GetChild(2).gameObject.SetActive(true);
            //animator.SetBool("OpenAnim", true);   E�er kullan�rsan <Image>().enabled = true; yu de aktif et
        }
        else if (IsMenuOpen)
        {
            //Debug.Log("men� kapand�");
            IsMenuOpen = false;
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
            //this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
            //animator.SetBool("OpenAnim", false);   E�er kullan�rsan <Image>().enabled = true; yu de aktif et
        }
    }
    public void CloseMenu()
    {
        //Debug.Log("men� kapand�");
        IsMenuOpen = false;
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
        //this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
        //animator.SetBool("OpenAnim", false);   E�er kullan�rsan <Image>().enabled = true; yu de aktif et
    }

    public void ToggleSound()
    {
        if (IsSoundTurnedOn)
        {
            Debug.Log("ses kapand�");
            this.gameObject.transform.GetChild(2).gameObject.GetComponent<Image>().sprite = _OffSound;
            IsSoundTurnedOn = false;
        }
        else
        {
            Debug.Log("ses a��ld�");
            this.gameObject.transform.GetChild(2).gameObject.GetComponent<Image>().sprite = _OnSound;
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
