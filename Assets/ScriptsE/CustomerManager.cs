using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public int musteriOlmaSansii; //NPC'nin m��teri olma �ans�. (Y�zdesel Olarak)
    public BakilacakYon bakilacakYon;
    public int sahnedeKacAdetParkPointVar;
    public bool[] parkPointsBusy;

    public List<GameObject> musterilerList = new List<GameObject>();
    public List<GameObject> siparisSirasi = new List<GameObject>();

    public enum BakilacakYon
    {
        artiX,
        eksiX,
        artiZ,
        eksiZ,
    }


    void Start()
    {
        ParkPointResetAndRebuild();
    }

    public void ParkPointResetAndRebuild()
    {
        musterilerList.Clear();
        siparisSirasi.Clear();

        for (int i = 0; i < sahnedeKacAdetParkPointVar; i++)
        {
            musterilerList.Add(null);
        }

        parkPointsBusy = new bool[sahnedeKacAdetParkPointVar];
        for (int i = 0; i < parkPointsBusy.Length; i++)
        {
            parkPointsBusy[i] = false;
        }
    }   //T�m parkPointleri s�f�rlar //Ba�lang��ta �al��t�r�lmas� gerek








}
