using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PriceChangeUpdater : MonoBehaviour
{
    // Изменяет показатели цен в магазине и их описание.
    public List<TextMeshProUGUI> PriceList;
    public OblectSwapSystem OblectSwapSystem;
    public string cost = "Цена: ";
    private void Start()
    {
        PriceList[0].text = cost + OblectSwapSystem.dualPopitCost.ToString();
        PriceList[1].text = cost + OblectSwapSystem.fivePopitCost.ToString();
        PriceList[2].text = cost + OblectSwapSystem.ninePopitCost.ToString();
        PriceList[3].text = cost + OblectSwapSystem.classicPopitCost.ToString();
        PriceList[4].text = cost + OblectSwapSystem.amongasPopitCost.ToString();
    }
}
