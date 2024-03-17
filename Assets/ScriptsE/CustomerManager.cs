using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public int musteriOlmaSansii; //NPC'nin müþteri olma þansý. (Yüzdesel Olarak)
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
    }   //Tüm parkPointleri sýfýrlar //Baþlangýçta çalýþtýrýlmasý gerek








}
