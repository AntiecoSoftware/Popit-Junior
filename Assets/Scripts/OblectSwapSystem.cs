using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OblectSwapSystem : MonoBehaviour
{
    public int indexButton;
    private int indexButtonChange;


    // Индикаторы покупки попита указывается в инспекторе
    public int dualPopitCost;
    public bool DualPopitBuyed;

    public int fivePopitCost;
    public bool FivePopitBuyed;
    
    public int ninePopitCost;
    public bool NinePopitBuyed;
    
    public int classicPopitCost;
    public bool ClassicPopitBuyed;
    
    public int amongasPopitCost;
    public bool AmongasPopitBuyed;

    public CoutParametrs CP;
    public BtnBuyIndicator BBI;
    public List<GameObject> objectsToSwap;

    public AudioSource accept;
    public AudioSource cancel;
    public AudioSource byed;

    private int startAudioStopper;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ObjectSwap();
    }

    // Функция смены объектов в зависимости от выбранного индекса
    private void ObjectSwap()
    {
        if (indexButton != indexButtonChange)
        {
            indexButtonChange = indexButton;

            for (int i = 0; i < objectsToSwap.Count; i++)
            {
                if (i == indexButton)
                {
                    // Сделать что-то с этим кастылём 14.09.21
                    startAudioStopper++;
                    if(startAudioStopper >= 2)
                    {
                        accept.Play();
                    }
                    //----------------------------------------------
                    objectsToSwap[i].SetActive(true);
                }
                else
                {
                    objectsToSwap[i].SetActive(false);
                }
            }
        }
    }

    // Задаёт индексы кнопкам
    //--------------------------------------------------------------------------------
    public void DualPopitIndex()
    {
        if (DualPopitBuyed == true)
        {
            indexButton = 0;
        }

    }

    public void FivePopitIndex()
    {
        if (FivePopitBuyed == true)
        {
            indexButton = 1;
        }

    }

    public void NinePopitIndex()
    {
        if (NinePopitBuyed == true)
        {
            indexButton = 2;
        }

    }

    public void ClassicPopitIndex()
    {
        if (ClassicPopitBuyed == true)
        {
            indexButton = 3;
        }
    }

    public void AmongasPopitIndex()
    {
        if (AmongasPopitBuyed == true)
        {
            indexButton = 4;
        }
    }
    //------------------------------------------------------------------------------

    // Покупает попыт
    public void FivePopitBuy()
    {
        if (CP.coutMain >= fivePopitCost)
        {
            byed.Play();
            CP.coutChange -= fivePopitCost;
            FivePopitBuyed = true;
            // Свапает кнопки в меню магазина при покупке.
            BBI.AllCallBought();
        }
        else
        {
            cancel.Play();
        }
    }
    public void NinePopitBuy()
    {
        if (CP.coutMain >= ninePopitCost)
        {
            byed.Play();
            CP.coutChange -= ninePopitCost;
            NinePopitBuyed = true;
            BBI.AllCallBought();

        }
        else
        {
            cancel.Play();
        }
    }
    public void ClassicPopitBuy()
    {
        if (CP.coutMain >= classicPopitCost)
        {
            byed.Play();
            CP.coutChange -= classicPopitCost;
            ClassicPopitBuyed = true;
            BBI.AllCallBought();

        }
        else
        {
            cancel.Play();
        }
    }
    public void AmongasPopitBuy()
    {
        if (CP.coutMain >= amongasPopitCost)
        {
            byed.Play();
            CP.coutChange -= amongasPopitCost;
            AmongasPopitBuyed = true;
            BBI.AllCallBought();

        }
        else
        {
            cancel.Play();
        }
    }
    //------------------------------------------------------------------------------
}

