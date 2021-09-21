using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnBuyIndicator : MonoBehaviour
{
    public OblectSwapSystem oSwapSys;
    public List<GameObject> ButtonBuyedIndicator;
    public List<GameObject> ButtonBusketIndicator;

    private void Start()
    {
        AllCallBought();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AllCallBought()
    {
        DualPopitBought();
        FivePopitBought();
        NinePopitBought();
        ClassicPopitBought();
        AmongasPopitBought();
    }

    public void DualPopitBought()
    {
        if (oSwapSys.DualPopitBuyed == true)
        {
            ButtonBuyedIndicator[0].SetActive(true);
            ButtonBusketIndicator[0].SetActive(false);
        }
        else
        {
            ButtonBuyedIndicator[0].SetActive(false);
            ButtonBusketIndicator[0].SetActive(true);
        }

    }
    public void FivePopitBought()
    {
        if (oSwapSys.FivePopitBuyed == true)
        {
            ButtonBuyedIndicator[1].SetActive(true);
            ButtonBusketIndicator[1].SetActive(false);
        }
        else
        {
            ButtonBuyedIndicator[1].SetActive(false);
            ButtonBusketIndicator[1].SetActive(true);
        }
    }
    public void NinePopitBought()
    {
        if (oSwapSys.NinePopitBuyed == true)
        {
            ButtonBuyedIndicator[2].SetActive(true);
            ButtonBusketIndicator[2].SetActive(false);
        }
        else
        {
            ButtonBuyedIndicator[2].SetActive(false);
            ButtonBusketIndicator[2].SetActive(true);
        }
    }
    public void ClassicPopitBought()
    {
        if (oSwapSys.ClassicPopitBuyed == true)
        {
            ButtonBuyedIndicator[3].SetActive(true);
            ButtonBusketIndicator[3].SetActive(false);
        }
        else
        {
            ButtonBuyedIndicator[3].SetActive(false);
            ButtonBusketIndicator[3].SetActive(true);
        }
    }
    public void AmongasPopitBought()
    {
        if (oSwapSys.AmongasPopitBuyed == true)
        {
            ButtonBuyedIndicator[4].SetActive(true);
            ButtonBusketIndicator[4].SetActive(false);
        }
        else
        {
            ButtonBuyedIndicator[4].SetActive(false);
            ButtonBusketIndicator[4].SetActive(true);
        }
    }
}
